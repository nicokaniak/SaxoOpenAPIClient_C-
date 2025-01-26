using System;
using System.Collections.Concurrent;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace SaxoOpenAPIClient.Streaming
{
    /// <summary>
    /// Implementation of the streaming connection to Saxo Bank's WebSocket API
    /// </summary>
    public class StreamingConnection : IStreamingConnection
    {
        private readonly ILogger<StreamingConnection> _logger;
        private readonly SaxoClientOptions _options;
        private readonly ConcurrentDictionary<string, object> _subscriptions;
        private readonly ClientWebSocket _webSocket;
        private readonly CancellationTokenSource _connectionCts;
        private readonly JsonSerializerOptions _jsonOptions;

        private ConnectionState _state;
        private Task _receiveTask;

        public ConnectionState State
        {
            get => _state;
            private set
            {
                if (_state != value)
                {
                    var oldState = _state;
                    _state = value;
                    OnStateChanged(oldState, value);
                }
            }
        }

        public event EventHandler<ConnectionStateChangedEventArgs> StateChanged;
        public event EventHandler<MessageReceivedEventArgs> MessageReceived;

        public StreamingConnection(
            IOptions<SaxoClientOptions> options,
            ILogger<StreamingConnection> logger)
        {
            _logger = logger;
            _options = options.Value;
            _subscriptions = new ConcurrentDictionary<string, object>();
            _webSocket = new ClientWebSocket();
            _connectionCts = new CancellationTokenSource();
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            State = ConnectionState.Disconnected;
        }

        public async Task StartAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                State = ConnectionState.Connecting;

                var uri = new Uri($"{_options.StreamingUrl}");
                await _webSocket.ConnectAsync(uri, cancellationToken);

                State = ConnectionState.Connected;

                _receiveTask = ReceiveLoopAsync(_connectionCts.Token);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to start streaming connection");
                State = ConnectionState.Failed;
                throw;
            }
        }

        public async Task StopAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                _connectionCts.Cancel();

                if (_webSocket.State == WebSocketState.Open)
                {
                    await _webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", cancellationToken);
                }

                if (_receiveTask != null)
                {
                    await _receiveTask;
                }

                State = ConnectionState.Disconnected;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error stopping streaming connection");
                throw;
            }
        }

        public async Task<string> CreateSubscriptionAsync<T>(SubscriptionRequest request, CancellationToken cancellationToken = default) where T : class
        {
            var referenceId = request.ReferenceId ?? Guid.NewGuid().ToString();
            request.ReferenceId = referenceId;

            var message = JsonSerializer.Serialize(request, _jsonOptions);
            var buffer = Encoding.UTF8.GetBytes(message);

            await _webSocket.SendAsync(
                new ArraySegment<byte>(buffer),
                WebSocketMessageType.Text,
                true,
                cancellationToken);

            _subscriptions.TryAdd(referenceId, typeof(T));

            return referenceId;
        }

        public async Task ModifySubscriptionAsync(string referenceId, SubscriptionModifyRequest request, CancellationToken cancellationToken = default)
        {
            var message = JsonSerializer.Serialize(new
            {
                ReferenceId = referenceId,
                request.Arguments,
                request.RefreshRate
            }, _jsonOptions);

            var buffer = Encoding.UTF8.GetBytes(message);

            await _webSocket.SendAsync(
                new ArraySegment<byte>(buffer),
                WebSocketMessageType.Text,
                true,
                cancellationToken);
        }

        public async Task RemoveSubscriptionAsync(string referenceId, CancellationToken cancellationToken = default)
        {
            var message = JsonSerializer.Serialize(new
            {
                ReferenceId = referenceId,
                Command = "unsubscribe"
            }, _jsonOptions);

            var buffer = Encoding.UTF8.GetBytes(message);

            await _webSocket.SendAsync(
                new ArraySegment<byte>(buffer),
                WebSocketMessageType.Text,
                true,
                cancellationToken);

            _subscriptions.TryRemove(referenceId, out _);
        }

        public async Task ResetSubscriptionsAsync(CancellationToken cancellationToken = default)
        {
            foreach (var subscription in _subscriptions)
            {
                await RemoveSubscriptionAsync(subscription.Key, cancellationToken);
            }
        }

        private async Task ReceiveLoopAsync(CancellationToken cancellationToken)
        {
            var buffer = new byte[4096];

            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    var result = await _webSocket.ReceiveAsync(
                        new ArraySegment<byte>(buffer),
                        cancellationToken);

                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        await HandleConnectionCloseAsync();
                        break;
                    }

                    if (result.MessageType == WebSocketMessageType.Text)
                    {
                        var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                        await HandleMessageAsync(message);
                    }
                }
            }
            catch (OperationCanceledException)
            {
                // Normal cancellation, ignore
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in receive loop");
                State = ConnectionState.Failed;
            }
        }

        private async Task HandleConnectionCloseAsync()
        {
            State = ConnectionState.Disconnected;

            if (_webSocket.CloseStatus == WebSocketCloseStatus.Empty)
            {
                // Unexpected close, attempt to reconnect
                await AttemptReconnectAsync();
            }
        }

        private async Task HandleMessageAsync(string message)
        {
            try
            {
                var baseMessage = JsonSerializer.Deserialize<StreamingPayload<object>>(message, _jsonOptions);

                if (_subscriptions.TryGetValue(baseMessage.ReferenceId, out var type))
                {
                    MessageReceived?.Invoke(this, new MessageReceivedEventArgs(
                        baseMessage.ReferenceId,
                        type.ToString(),
                        baseMessage.Data));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error handling message: {Message}", message);
            }
        }

        private async Task AttemptReconnectAsync()
        {
            State = ConnectionState.Reconnecting;

            try
            {
                await StartAsync();

                // Resubscribe to all active subscriptions
                foreach (var subscription in _subscriptions)
                {
                    // Implementation depends on how you store subscription details
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to reconnect");
                State = ConnectionState.Failed;
            }
        }

        private void OnStateChanged(ConnectionState oldState, ConnectionState newState)
        {
            StateChanged?.Invoke(this, new ConnectionStateChangedEventArgs(oldState, newState));
        }

        public void Dispose()
        {
            _connectionCts.Cancel();
            _connectionCts.Dispose();
            _webSocket.Dispose();
        }
    }
}
