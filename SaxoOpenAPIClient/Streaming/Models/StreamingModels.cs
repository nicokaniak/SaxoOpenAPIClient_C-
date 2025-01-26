using System;
using System.Text.Json.Serialization;

namespace SaxoOpenAPIClient.Streaming
{
    /// <summary>
    /// Connection states for the streaming connection
    /// </summary>
    public enum ConnectionState
    {
        Disconnected,
        Connecting,
        Connected,
        Reconnecting,
        Failed
    }

    /// <summary>
    /// Event arguments for connection state changes
    /// </summary>
    public class ConnectionStateChangedEventArgs : EventArgs
    {
        public ConnectionState OldState { get; }
        public ConnectionState NewState { get; }
        public Exception Exception { get; }

        public ConnectionStateChangedEventArgs(ConnectionState oldState, ConnectionState newState, Exception exception = null)
        {
            OldState = oldState;
            NewState = newState;
            Exception = exception;
        }
    }

    /// <summary>
    /// Event arguments for received messages
    /// </summary>
    public class MessageReceivedEventArgs : EventArgs
    {
        public string ReferenceId { get; }
        public string SchemaName { get; }
        public object Payload { get; }

        public MessageReceivedEventArgs(string referenceId, string schemaName, object payload)
        {
            ReferenceId = referenceId;
            SchemaName = schemaName;
            Payload = payload;
        }
    }

    /// <summary>
    /// Base class for subscription requests
    /// </summary>
    public class SubscriptionRequest
    {
        [JsonPropertyName("ReferenceId")]
        public string ReferenceId { get; set; }

        [JsonPropertyName("Arguments")]
        public object Arguments { get; set; }

        [JsonPropertyName("ContextId")]
        public string ContextId { get; set; }

        [JsonPropertyName("Format")]
        public string Format { get; set; } = "application/json";

        [JsonPropertyName("RefreshRate")]
        public int? RefreshRate { get; set; }
    }

    /// <summary>
    /// Request to modify an existing subscription
    /// </summary>
    public class SubscriptionModifyRequest
    {
        [JsonPropertyName("Arguments")]
        public object Arguments { get; set; }

        [JsonPropertyName("RefreshRate")]
        public int? RefreshRate { get; set; }
    }

    /// <summary>
    /// Base class for streaming data payloads
    /// </summary>
    public class StreamingPayload<T>
    {
        [JsonPropertyName("MessageId")]
        public int MessageId { get; set; }

        [JsonPropertyName("ReferenceId")]
        public string ReferenceId { get; set; }

        [JsonPropertyName("Data")]
        public T[] Data { get; set; }
    }

    /// <summary>
    /// Heartbeat message payload
    /// </summary>
    public class HeartbeatPayload
    {
        [JsonPropertyName("Timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonPropertyName("ConnectionId")]
        public string ConnectionId { get; set; }
    }
}
