using System;
using System.Text.Json.Serialization;

namespace SaxoOpenAPIClient.Services.Trading.Models
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

        [JsonPropertyName("OrderDuration")]
        public OrderDuration OrderDuration { get; set; }

        [JsonPropertyName("OrderPrice")]
        public decimal? OrderPrice { get; set; }

        [JsonPropertyName("Uic")]
        public int Uic { get; set; }
    }

    public class OrderResponse
    {
        [JsonPropertyName("OrderId")]
        public string OrderId { get; set; }

        [JsonPropertyName("Status")]
        public string Status { get; set; }

        [JsonPropertyName("ErrorInfo")]
        public ErrorInfo ErrorInfo { get; set; }
    }

    public class OrderInfo
    {
        [JsonPropertyName("OrderId")]
        public string OrderId { get; set; }

        [JsonPropertyName("Status")]
        public string Status { get; set; }

        [JsonPropertyName("FilledAmount")]
        public decimal FilledAmount { get; set; }

        [JsonPropertyName("OrderPrice")]
        public decimal OrderPrice { get; set; }

        [JsonPropertyName("FilledPrice")]
        public decimal? FilledPrice { get; set; }

        [JsonPropertyName("CreateTime")]
        public DateTime CreateTime { get; set; }

        [JsonPropertyName("LastUpdateTime")]
        public DateTime LastUpdateTime { get; set; }
    }

    public class OrderList
    {
        [JsonPropertyName("Data")]
        public OrderInfo[] Orders { get; set; }

        [JsonPropertyName("Count")]
        public int Count { get; set; }
    }

    public class OrderDuration
    {
        [JsonPropertyName("DurationType")]
        public string DurationType { get; set; }

        [JsonPropertyName("ExpirationDateTime")]
        public DateTime? ExpirationDateTime { get; set; }
    }

    public class ErrorInfo
    {
        [JsonPropertyName("ErrorCode")]
        public string ErrorCode { get; set; }

        [JsonPropertyName("Message")]
        public string Message { get; set; }
    }

    public class PositionList
    {
        [JsonPropertyName("Data")]
        public Position[] Positions { get; set; }

        [JsonPropertyName("Count")]
        public int Count { get; set; }
    }

    public class Position
    {
        [JsonPropertyName("PositionId")]
        public string PositionId { get; set; }

        [JsonPropertyName("AssetType")]
        public string AssetType { get; set; }

        [JsonPropertyName("Amount")]
        public decimal Amount { get; set; }

        [JsonPropertyName("OpenPrice")]
        public decimal OpenPrice { get; set; }

        [JsonPropertyName("CurrentPrice")]
        public decimal CurrentPrice { get; set; }

        [JsonPropertyName("ProfitLoss")]
        public decimal ProfitLoss { get; set; }
    }
}
