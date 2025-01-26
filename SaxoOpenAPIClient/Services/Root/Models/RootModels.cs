using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SaxoOpenAPIClient.Services.Root.Models
{
    public class SessionInfo
    {
        [JsonPropertyName("SessionId")]
        public string SessionId { get; set; }

        [JsonPropertyName("ExpirationDateTime")]
        public DateTime ExpirationDateTime { get; set; }

        [JsonPropertyName("ClientKey")]
        public string ClientKey { get; set; }

        [JsonPropertyName("UserId")]
        public string UserId { get; set; }
    }

    public class FeatureAvailability
    {
        [JsonPropertyName("Features")]
        public List<Feature> Features { get; set; }
    }

    public class Feature
    {
        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("Enabled")]
        public bool Enabled { get; set; }

        [JsonPropertyName("Description")]
        public string Description { get; set; }
    }

    public class UserInfo
    {
        [JsonPropertyName("UserId")]
        public string UserId { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("Language")]
        public string Language { get; set; }

        [JsonPropertyName("TimeZoneId")]
        public string TimeZoneId { get; set; }
    }

    public class UserInfoV2 : UserInfo
    {
        [JsonPropertyName("MarketDataVendorId")]
        public string MarketDataVendorId { get; set; }

        [JsonPropertyName("DefaultAccountKey")]
        public string DefaultAccountKey { get; set; }

        [JsonPropertyName("DefaultCurrency")]
        public string DefaultCurrency { get; set; }

        [JsonPropertyName("LegalAssetTypes")]
        public List<string> LegalAssetTypes { get; set; }
    }

    public class DiagnosticsInfo
    {
        [JsonPropertyName("Build")]
        public string Build { get; set; }

        [JsonPropertyName("Version")]
        public string Version { get; set; }

        [JsonPropertyName("Server")]
        public string Server { get; set; }

        [JsonPropertyName("ProcessId")]
        public string ProcessId { get; set; }

        [JsonPropertyName("MachineName")]
        public string MachineName { get; set; }
    }

    public class SubscriptionList
    {
        [JsonPropertyName("Data")]
        public List<Subscription> Subscriptions { get; set; }
    }

    public class Subscription
    {
        [JsonPropertyName("ContextId")]
        public string ContextId { get; set; }

        [JsonPropertyName("ReferenceId")]
        public string ReferenceId { get; set; }

        [JsonPropertyName("Format")]
        public string Format { get; set; }

        [JsonPropertyName("SchemaName")]
        public string SchemaName { get; set; }

        [JsonPropertyName("State")]
        public string State { get; set; }
    }

    public class RateLimitInfo
    {
        [JsonPropertyName("Limit")]
        public int Limit { get; set; }

        [JsonPropertyName("Remaining")]
        public int Remaining { get; set; }

        [JsonPropertyName("Reset")]
        public DateTime Reset { get; set; }
    }
}
