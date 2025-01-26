using System;
using System.Threading;
using System.Threading.Tasks;

namespace SaxoOpenAPIClient.Streaming
{
    /// <summary>
    /// Interface for managing WebSocket connections to Saxo Bank's streaming API
    /// </summary>
    public interface IStreamingConnection : IDisposable
    {
        /// <summary>
        /// Current connection state
        /// </summary>
        ConnectionState State { get; }

        /// <summary>
        /// Event raised when connection state changes
        /// </summary>
        event EventHandler<ConnectionStateChangedEventArgs> StateChanged;

        /// <summary>
        /// Event raised when a message is received
        /// </summary>
        event EventHandler<MessageReceivedEventArgs> MessageReceived;

        /// <summary>
        /// Starts the connection
        /// </summary>
        Task StartAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Stops the connection
        /// </summary>
        Task StopAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a new subscription
        /// </summary>
        Task<string> CreateSubscriptionAsync<T>(SubscriptionRequest request, CancellationToken cancellationToken = default) where T : class;

        /// <summary>
        /// Modifies an existing subscription
        /// </summary>
        Task ModifySubscriptionAsync(string referenceId, SubscriptionModifyRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Removes an existing subscription
        /// </summary>
        Task RemoveSubscriptionAsync(string referenceId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Resets all subscriptions
        /// </summary>
        Task ResetSubscriptionsAsync(CancellationToken cancellationToken = default);
    }
}
