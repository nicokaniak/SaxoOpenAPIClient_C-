using System;
using System.Text.Json.Serialization;

namespace SaxoOpenAPIClient.Services.Trading.Orders.Models
{
    /// <summary>
    /// Base class for all order requests
    /// </summary>
    public abstract class OrderBase
    {
        [JsonPropertyName("AccountKey")]
        public string AccountKey { get; set; }

        [JsonPropertyName("AssetType")]
        public string AssetType { get; set; }

        [JsonPropertyName("Amount")]
        public decimal Amount { get; set; }

        [JsonPropertyName("BuySell")]
        public string BuySell { get; set; }

        [JsonPropertyName("Uic")]
        public int Uic { get; set; }

        [JsonPropertyName("OrderType")]
        public string OrderType { get; set; }

        [JsonPropertyName("OrderDuration")]
        public OrderDuration OrderDuration { get; set; }

        [JsonPropertyName("OrderPrice")]
        public decimal? OrderPrice { get; set; }

        [JsonPropertyName("ExternalReference")]
        public string ExternalReference { get; set; }

        [JsonPropertyName("ManualOrder")]
        public bool ManualOrder { get; set; }
    }

    /// <summary>
    /// Standard single-leg order request
    /// </summary>
    public class OrderRequest : OrderBase
    {
        [JsonPropertyName("OrderRelation")]
        public string OrderRelation { get; set; }

        [JsonPropertyName("StopLimitPrice")]
        public decimal? StopLimitPrice { get; set; }

        [JsonPropertyName("TrailingStopDistanceToMarket")]
        public decimal? TrailingStopDistanceToMarket { get; set; }

        [JsonPropertyName("TrailingStopStep")]
        public decimal? TrailingStopStep { get; set; }
    }

    /// <summary>
    /// Multi-leg option strategy order request
    /// </summary>
    public class MultiLegOrderRequest : OrderBase
    {
        [JsonPropertyName("StrategyType")]
        public string StrategyType { get; set; }

        [JsonPropertyName("Legs")]
        public OrderLeg[] Legs { get; set; }
    }

    /// <summary>
    /// Individual leg in a multi-leg order
    /// </summary>
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

    /// <summary>
    /// OCO (One-Cancels-Other) order request
    /// </summary>
    public class OcoOrderRequest
    {
        [JsonPropertyName("Orders")]
        public OrderRequest[] Orders { get; set; }
    }

    /// <summary>
    /// Algorithmic order request
    /// </summary>
    public class AlgoOrderRequest : OrderBase
    {
        [JsonPropertyName("AlgoStrategyName")]
        public string AlgoStrategyName { get; set; }

        [JsonPropertyName("Parameters")]
        public AlgoParameters Parameters { get; set; }
    }

    /// <summary>
    /// Parameters for algorithmic orders
    /// </summary>
    public class AlgoParameters
    {
        [JsonPropertyName("StartTime")]
        public DateTime? StartTime { get; set; }

        [JsonPropertyName("EndTime")]
        public DateTime? EndTime { get; set; }

        [JsonPropertyName("DisplaySize")]
        public decimal? DisplaySize { get; set; }

        [JsonPropertyName("ParticipationRate")]
        public decimal? ParticipationRate { get; set; }
    }

    /// <summary>
    /// Conditional order request
    /// </summary>
    public class ConditionalOrderRequest : OrderRequest
    {
        [JsonPropertyName("OrderCondition")]
        public OrderCondition Condition { get; set; }
    }

    /// <summary>
    /// Condition for conditional orders
    /// </summary>
    public class OrderCondition
    {
        [JsonPropertyName("TriggerType")]
        public string TriggerType { get; set; }

        [JsonPropertyName("TriggerValue")]
        public decimal TriggerValue { get; set; }

        [JsonPropertyName("Price")]
        public decimal Price { get; set; }
    }

    /// <summary>
    /// Order duration specification
    /// </summary>
    public class OrderDuration
    {
        [JsonPropertyName("DurationType")]
        public string DurationType { get; set; }

        [JsonPropertyName("ExpirationDateTime")]
        public DateTime? ExpirationDateTime { get; set; }

        [JsonPropertyName("ExpirationDateContainsTime")]
        public bool? ExpirationDateContainsTime { get; set; }
    }

    /// <summary>
    /// Response for order operations
    /// </summary>
    public class OrderResponse
    {
        [JsonPropertyName("OrderId")]
        public string OrderId { get; set; }

        [JsonPropertyName("Orders")]
        public OrderDetails[] Orders { get; set; }
    }

    /// <summary>
    /// Detailed order information
    /// </summary>
    public class OrderDetails
    {
        [JsonPropertyName("OrderId")]
        public string OrderId { get; set; }

        [JsonPropertyName("Status")]
        public string Status { get; set; }

        [JsonPropertyName("StatusDescription")]
        public string StatusDescription { get; set; }

        [JsonPropertyName("FilledAmount")]
        public decimal FilledAmount { get; set; }

        [JsonPropertyName("RemainingAmount")]
        public decimal RemainingAmount { get; set; }

        [JsonPropertyName("CancelledAmount")]
        public decimal CancelledAmount { get; set; }
    }
}
