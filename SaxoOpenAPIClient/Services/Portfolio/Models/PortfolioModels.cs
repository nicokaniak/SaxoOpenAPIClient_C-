using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SaxoOpenAPIClient.Services.Portfolio.Models
{
    /// <summary>
    /// Portfolio account balance information
    /// </summary>
    public class AccountBalance
    {
        [JsonPropertyName("CashBalance")]
        public decimal CashBalance { get; set; }

        [JsonPropertyName("TotalValue")]
        public decimal TotalValue { get; set; }

        [JsonPropertyName("NetEquityForMargin")]
        public decimal NetEquityForMargin { get; set; }

        [JsonPropertyName("MarginUtilization")]
        public decimal MarginUtilization { get; set; }

        [JsonPropertyName("AvailableMargin")]
        public decimal AvailableMargin { get; set; }

        [JsonPropertyName("Currency")]
        public string Currency { get; set; }
    }

    /// <summary>
    /// Portfolio position information
    /// </summary>
    public class Position
    {
        [JsonPropertyName("PositionId")]
        public string PositionId { get; set; }

        [JsonPropertyName("AccountKey")]
        public string AccountKey { get; set; }

        [JsonPropertyName("AssetType")]
        public string AssetType { get; set; }

        [JsonPropertyName("Amount")]
        public decimal Amount { get; set; }

        [JsonPropertyName("OpenPrice")]
        public decimal OpenPrice { get; set; }

        [JsonPropertyName("CurrentPrice")]
        public decimal CurrentPrice { get; set; }

        [JsonPropertyName("ProfitLossOnTrade")]
        public decimal ProfitLossOnTrade { get; set; }

        [JsonPropertyName("OpenDateTime")]
        public DateTime OpenDateTime { get; set; }

        [JsonPropertyName("Status")]
        public string Status { get; set; }
    }

    /// <summary>
    /// Position netting mode
    /// </summary>
    public class NettingProfile
    {
        [JsonPropertyName("AccountKey")]
        public string AccountKey { get; set; }

        [JsonPropertyName("AssetType")]
        public string AssetType { get; set; }

        [JsonPropertyName("NettingMode")]
        public string NettingMode { get; set; }

        [JsonPropertyName("Uic")]
        public int? Uic { get; set; }
    }

    /// <summary>
    /// Portfolio performance metrics
    /// </summary>
    public class PortfolioPerformance
    {
        [JsonPropertyName("AccountKey")]
        public string AccountKey { get; set; }

        [JsonPropertyName("Currency")]
        public string Currency { get; set; }

        [JsonPropertyName("PerformanceMetrics")]
        public List<PerformanceMetric> Metrics { get; set; }
    }

    /// <summary>
    /// Individual performance metric
    /// </summary>
    public class PerformanceMetric
    {
        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("Value")]
        public decimal Value { get; set; }

        [JsonPropertyName("Period")]
        public string Period { get; set; }
    }

    /// <summary>
    /// Margin requirement information
    /// </summary>
    public class MarginRequirement
    {
        [JsonPropertyName("InitialMargin")]
        public decimal InitialMargin { get; set; }

        [JsonPropertyName("MaintenanceMargin")]
        public decimal MaintenanceMargin { get; set; }

        [JsonPropertyName("CollateralAvailable")]
        public decimal CollateralAvailable { get; set; }

        [JsonPropertyName("MarginUtilization")]
        public decimal MarginUtilization { get; set; }
    }

    /// <summary>
    /// Report generation request
    /// </summary>
    public class ReportRequest
    {
        [JsonPropertyName("ReportType")]
        public string ReportType { get; set; }

        [JsonPropertyName("AccountKey")]
        public string AccountKey { get; set; }

        [JsonPropertyName("FromDate")]
        public DateTime FromDate { get; set; }

        [JsonPropertyName("ToDate")]
        public DateTime ToDate { get; set; }

        [JsonPropertyName("Format")]
        public string Format { get; set; }

        [JsonPropertyName("Language")]
        public string Language { get; set; }
    }

    /// <summary>
    /// Report generation response
    /// </summary>
    public class ReportResponse
    {
        [JsonPropertyName("ReportId")]
        public string ReportId { get; set; }

        [JsonPropertyName("Status")]
        public string Status { get; set; }

        [JsonPropertyName("Url")]
        public string Url { get; set; }
    }
}
