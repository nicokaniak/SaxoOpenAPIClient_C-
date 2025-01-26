using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace SaxoOpenAPIClient.Services.Trading.Orders.Models
{
    public class OrderRequest
    {
        [JsonPropertyName("AccountKey")]
        public string AccountKey { get; set; }

        [JsonPropertyName("AssetType")]
        public string AssetType { get; set; }

        [JsonPropertyName("Amount")]
        public decimal Amount { get; set; }

        [JsonPropertyName("BuySell")]
        public string BuySell { get; set; }

        [JsonPropertyName("OrderType")]
        public string OrderType { get; set; }

        [JsonPropertyName("OrderPrice")]
        public decimal? OrderPrice { get; set; }

        [JsonPropertyName("OrderDuration")]
        public OrderDuration OrderDuration { get; set; }

        [JsonPropertyName("ManualOrder")]
        public bool ManualOrder { get; set; }

        [JsonPropertyName("OrderRelation")]
        public string OrderRelation { get; set; }

        [JsonPropertyName("ExternalReference")]
        public string ExternalReference { get; set; }

        [JsonPropertyName("HandleInstructionInEventsFolder")]
        public bool HandleInstructionInEventsFolder { get; set; }
    }

    public class MultiLegOrderRequest
    {
        [JsonPropertyName("AccountKey")]
        public string AccountKey { get; set; }

        [JsonPropertyName("AssetType")]
        public string AssetType { get; set; }

        [JsonPropertyName("StrategyType")]
        public string StrategyType { get; set; }

        [JsonPropertyName("Legs")]
        public List<OrderLeg> Legs { get; set; }

        [JsonPropertyName("ExternalReference")]
        public string ExternalReference { get; set; }
    }

    public class OrderLeg
    {
        [JsonPropertyName("Uic")]
        public int Uic { get; set; }

        [JsonPropertyName("Amount")]
        public decimal Amount { get; set; }

        [JsonPropertyName("BuySell")]
        public string BuySell { get; set; }

        [JsonPropertyName("ToOpenClose")]
        public string ToOpenClose { get; set; }
    }

    public class OrderDuration
    {
        [JsonPropertyName("DurationType")]
        public string DurationType { get; set; }

        [JsonPropertyName("ExpirationDateTime")]
        public DateTime? ExpirationDateTime { get; set; }

        [JsonPropertyName("ExpirationDateContainsTime")]
        public bool ExpirationDateContainsTime { get; set; }
    }

    public class OrderQueryParams
    {
        [JsonPropertyName("FieldGroups")]
        public List<string> FieldGroups { get; set; }

        [JsonPropertyName("Status")]
        public string Status { get; set; }

        [JsonPropertyName("OrderIds")]
        public List<string> OrderIds { get; set; }

        [JsonPropertyName("FromDateTime")]
        public DateTime? FromDateTime { get; set; }

        [JsonPropertyName("ToDateTime")]
        public DateTime? ToDateTime { get; set; }
    }

    public class OrderCapabilities
    {
        [JsonPropertyName("SupportedOrderTypes")]
        public List<string> SupportedOrderTypes { get; set; }

        [JsonPropertyName("SupportedOrderDurations")]
        public List<string> SupportedOrderDurations { get; set; }

        [JsonPropertyName("SupportedOrderRelations")]
        public List<string> SupportedOrderRelations { get; set; }

        [JsonPropertyName("DefaultAmount")]
        public decimal DefaultAmount { get; set; }

        [JsonPropertyName("MinimumAmount")]
        public decimal MinimumAmount { get; set; }

        [JsonPropertyName("MaximumAmount")]
        public decimal MaximumAmount { get; set; }

        [JsonPropertyName("AmountStep")]
        public decimal AmountStep { get; set; }
    }

    public class MultiLegDefaults
    {
        [JsonPropertyName("DefaultAmount")]
        public decimal DefaultAmount { get; set; }

        [JsonPropertyName("SupportedStrategyTypes")]
        public List<string> SupportedStrategyTypes { get; set; }

        [JsonPropertyName("MaximumNumberOfLegs")]
        public int MaximumNumberOfLegs { get; set; }
    }

    // Additional models for responses, conditional orders, OCO orders, etc.
    // would be defined here following the same pattern
}
