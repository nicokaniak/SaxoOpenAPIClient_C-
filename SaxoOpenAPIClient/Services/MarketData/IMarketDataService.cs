using System;
using System.Threading.Tasks;
using SaxoOpenAPIClient.Services.MarketData.Models;

namespace SaxoOpenAPIClient.Services.MarketData
{
    /// <summary>
    /// Interface for accessing Saxo Bank market data services
    /// </summary>
    public interface IMarketDataService : ISaxoService
    {
        /// <summary>
        /// Get real-time price information for specified instruments
        /// </summary>
        Task<PriceInfo> GetPriceInfoAsync(string assetType, int uic);

        /// <summary>
        /// Subscribe to real-time price updates
        /// </summary>
        Task<string> SubscribeToPricesAsync(string assetType, int uic, int? refreshRate = null);

        /// <summary>
        /// Get market depth information
        /// </summary>
        Task<MarketDepth> GetMarketDepthAsync(string assetType, int uic, int depth = 10);

        /// <summary>
        /// Subscribe to market depth updates
        /// </summary>
        Task<string> SubscribeToMarketDepthAsync(string assetType, int uic, int depth = 10, int? refreshRate = null);

        /// <summary>
        /// Get historical price data
        /// </summary>
        Task<HistoricalPrices> GetHistoricalPricesAsync(
            string assetType,
            int uic,
            string horizon,
            DateTime? from = null,
            DateTime? to = null,
            int? count = null);

        /// <summary>
        /// Get options chain data
        /// </summary>
        Task<OptionsChain> GetOptionsChainAsync(
            int uic,
            DateTime expiryDate,
            string optionRootId = null);

        /// <summary>
        /// Subscribe to options chain updates
        /// </summary>
        Task<string> SubscribeToOptionsChainAsync(
            int uic,
            DateTime expiryDate,
            string optionRootId = null,
            int? refreshRate = null);

        /// <summary>
        /// Get trade messages
        /// </summary>
        Task<TradeMessage[]> GetTradeMessagesAsync(
            DateTime from,
            DateTime to,
            string priority = null);

        /// <summary>
        /// Subscribe to trade messages
        /// </summary>
        Task<string> SubscribeToTradeMessagesAsync(string priority = null);

        /// <summary>
        /// Get intraday tick data
        /// </summary>
        Task<HistoricalPrices> GetIntradayTicksAsync(
            string assetType,
            int uic,
            DateTime from,
            DateTime to,
            int? pageSize = null);

        /// <summary>
        /// Get trade level status
        /// </summary>
        Task<string> GetTradeLevelStatusAsync(string assetType, int uic);

        /// <summary>
        /// Subscribe to trade level status updates
        /// </summary>
        Task<string> SubscribeToTradeLevelStatusAsync(string assetType, int uic);
    }
}
