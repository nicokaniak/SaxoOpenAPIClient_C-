using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SaxoOpenAPIClient.Services.MarketData.Models
{
    /// <summary>
    /// Real-time price information
    /// </summary>
    public class PriceInfo
    {
        [JsonPropertyName("AssetType")]
        public string AssetType { get; set; }

        [JsonPropertyName("LastUpdated")]
        public DateTime LastUpdated { get; set; }

        [JsonPropertyName("Quote")]
        public PriceQuote Quote { get; set; }
    }

    /// <summary>
    /// Price quote details
    /// </summary>
    public class PriceQuote
    {
        [JsonPropertyName("Ask")]
        public decimal Ask { get; set; }

        [JsonPropertyName("Bid")]
        public decimal Bid { get; set; }

        [JsonPropertyName("Mid")]
        public decimal Mid { get; set; }

        [JsonPropertyName("LastTraded")]
        public decimal? LastTraded { get; set; }

        [JsonPropertyName("Volume")]
        public decimal? Volume { get; set; }

        [JsonPropertyName("DayHigh")]
        public decimal? DayHigh { get; set; }

        [JsonPropertyName("DayLow")]
        public decimal? DayLow { get; set; }

        [JsonPropertyName("DayOpen")]
        public decimal? DayOpen { get; set; }

        [JsonPropertyName("DayClose")]
        public decimal? DayClose { get; set; }
    }

    /// <summary>
    /// Market depth information
    /// </summary>
    public class MarketDepth
    {
        [JsonPropertyName("Levels")]
        public List<DepthLevel> Levels { get; set; }

        [JsonPropertyName("IsComplete")]
        public bool IsComplete { get; set; }
    }

    /// <summary>
    /// Individual market depth level
    /// </summary>
    public class DepthLevel
    {
        [JsonPropertyName("Price")]
        public decimal Price { get; set; }

        [JsonPropertyName("Amount")]
        public decimal Amount { get; set; }

        [JsonPropertyName("Side")]
        public string Side { get; set; }

        [JsonPropertyName("OrderCount")]
        public int OrderCount { get; set; }
    }

    /// <summary>
    /// Historical price data
    /// </summary>
    public class HistoricalPrices
    {
        [JsonPropertyName("Data")]
        public List<OhlcPrice> Data { get; set; }

        [JsonPropertyName("HasMore")]
        public bool HasMore { get; set; }
    }

    /// <summary>
    /// OHLC price data point
    /// </summary>
    public class OhlcPrice
    {
        [JsonPropertyName("Time")]
        public DateTime Time { get; set; }

        [JsonPropertyName("Open")]
        public decimal Open { get; set; }

        [JsonPropertyName("High")]
        public decimal High { get; set; }

        [JsonPropertyName("Low")]
        public decimal Low { get; set; }

        [JsonPropertyName("Close")]
        public decimal Close { get; set; }

        [JsonPropertyName("Volume")]
        public decimal? Volume { get; set; }
    }

    /// <summary>
    /// Options chain information
    /// </summary>
    public class OptionsChain
    {
        [JsonPropertyName("Strikes")]
        public List<OptionStrike> Strikes { get; set; }

        [JsonPropertyName("ExpiryDate")]
        public DateTime ExpiryDate { get; set; }

        [JsonPropertyName("UnderlyingPrice")]
        public decimal UnderlyingPrice { get; set; }
    }

    /// <summary>
    /// Option strike information
    /// </summary>
    public class OptionStrike
    {
        [JsonPropertyName("Strike")]
        public decimal Strike { get; set; }

        [JsonPropertyName("CallUic")]
        public int CallUic { get; set; }

        [JsonPropertyName("PutUic")]
        public int PutUic { get; set; }

        [JsonPropertyName("CallPrice")]
        public PriceQuote CallPrice { get; set; }

        [JsonPropertyName("PutPrice")]
        public PriceQuote PutPrice { get; set; }
    }

    /// <summary>
    /// Trade message information
    /// </summary>
    public class TradeMessage
    {
        [JsonPropertyName("MessageId")]
        public string MessageId { get; set; }

        [JsonPropertyName("MessageType")]
        public string MessageType { get; set; }

        [JsonPropertyName("CreationTime")]
        public DateTime CreationTime { get; set; }

        [JsonPropertyName("Content")]
        public string Content { get; set; }

        [JsonPropertyName("Priority")]
        public string Priority { get; set; }
    }
}
