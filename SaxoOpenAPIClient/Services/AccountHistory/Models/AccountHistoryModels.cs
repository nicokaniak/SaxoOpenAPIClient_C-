using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SaxoOpenAPIClient.Services.AccountHistory.Models
{
    /// <summary>
    /// Account performance information
    /// </summary>
    public class AccountPerformance
    {
        [JsonPropertyName("AccountKey")]
        public string AccountKey { get; set; }

        [JsonPropertyName("Currency")]
        public string Currency { get; set; }

        [JsonPropertyName("FromDate")]
        public DateTime FromDate { get; set; }

        [JsonPropertyName("ToDate")]
        public DateTime ToDate { get; set; }

        [JsonPropertyName("Performance")]
        public List<PerformanceMetric> Metrics { get; set; }
    }

    /// <summary>
    /// Performance metric information
    /// </summary>
    public class PerformanceMetric
    {
        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("Value")]
        public decimal Value { get; set; }

        [JsonPropertyName("Type")]
        public string Type { get; set; }

        [JsonPropertyName("Date")]
        public DateTime? Date { get; set; }
    }

    /// <summary>
    /// Account statement information
    /// </summary>
    public class AccountStatement
    {
        [JsonPropertyName("AccountKey")]
        public string AccountKey { get; set; }

        [JsonPropertyName("FromDate")]
        public DateTime FromDate { get; set; }

        [JsonPropertyName("ToDate")]
        public DateTime ToDate { get; set; }

        [JsonPropertyName("Currency")]
        public string Currency { get; set; }

        [JsonPropertyName("Entries")]
        public List<StatementEntry> Entries { get; set; }
    }

    /// <summary>
    /// Individual statement entry
    /// </summary>
    public class StatementEntry
    {
        [JsonPropertyName("BookingDate")]
        public DateTime BookingDate { get; set; }

        [JsonPropertyName("Description")]
        public string Description { get; set; }

        [JsonPropertyName("AssetType")]
        public string AssetType { get; set; }

        [JsonPropertyName("Amount")]
        public decimal Amount { get; set; }

        [JsonPropertyName("TransactionType")]
        public string TransactionType { get; set; }

        [JsonPropertyName("CashBalance")]
        public decimal CashBalance { get; set; }
    }

    /// <summary>
    /// Unsettled amount information
    /// </summary>
    public class UnsettledAmount
    {
        [JsonPropertyName("AccountKey")]
        public string AccountKey { get; set; }

        [JsonPropertyName("Currency")]
        public string Currency { get; set; }

        [JsonPropertyName("SettlementDate")]
        public DateTime SettlementDate { get; set; }

        [JsonPropertyName("Amount")]
        public decimal Amount { get; set; }

        [JsonPropertyName("Status")]
        public string Status { get; set; }
    }

    /// <summary>
    /// Historical balance information
    /// </summary>
    public class HistoricalBalance
    {
        [JsonPropertyName("AccountKey")]
        public string AccountKey { get; set; }

        [JsonPropertyName("Currency")]
        public string Currency { get; set; }

        [JsonPropertyName("Date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("CashBalance")]
        public decimal CashBalance { get; set; }

        [JsonPropertyName("CostValue")]
        public decimal CostValue { get; set; }

        [JsonPropertyName("MarketValue")]
        public decimal MarketValue { get; set; }

        [JsonPropertyName("NetEquityForMargin")]
        public decimal NetEquityForMargin { get; set; }
    }

    /// <summary>
    /// Trade history information
    /// </summary>
    public class TradeHistory
    {
        [JsonPropertyName("AccountKey")]
        public string AccountKey { get; set; }

        [JsonPropertyName("FromDate")]
        public DateTime FromDate { get; set; }

        [JsonPropertyName("ToDate")]
        public DateTime ToDate { get; set; }

        [JsonPropertyName("Trades")]
        public List<HistoricalTrade> Trades { get; set; }
    }

    /// <summary>
    /// Historical trade information
    /// </summary>
    public class HistoricalTrade
    {
        [JsonPropertyName("TradeId")]
        public string TradeId { get; set; }

        [JsonPropertyName("OpenDateTime")]
        public DateTime OpenDateTime { get; set; }

        [JsonPropertyName("CloseDateTime")]
        public DateTime? CloseDateTime { get; set; }

        [JsonPropertyName("AssetType")]
        public string AssetType { get; set; }

        [JsonPropertyName("Amount")]
        public decimal Amount { get; set; }

        [JsonPropertyName("OpenPrice")]
        public decimal OpenPrice { get; set; }

        [JsonPropertyName("ClosePrice")]
        public decimal? ClosePrice { get; set; }

        [JsonPropertyName("ProfitLoss")]
        public decimal? ProfitLoss { get; set; }

        [JsonPropertyName("Status")]
        public string Status { get; set; }
    }
}
