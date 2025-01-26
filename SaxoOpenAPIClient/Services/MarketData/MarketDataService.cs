using System;
using System.Threading.Tasks;
using SaxoOpenAPIClient.Services.MarketData.Models;

namespace SaxoOpenAPIClient.Services.MarketData
{
    /// <summary>
    /// Implementation of Saxo Bank market data services
    /// </summary>
    public class MarketDataService : BaseSaxoService, IMarketDataService
    {
        private readonly IStreamingConnection _streamingConnection;

        public override string BaseEndpoint => ServiceEndpoints.MarketData;

        public MarketDataService(ISaxoClient client, IStreamingConnection streamingConnection)
            : base(client)
        {
            _streamingConnection = streamingConnection;
        }

        public async Task<PriceInfo> GetPriceInfoAsync(string assetType, int uic)
        {
            return await Client.GetAsync<PriceInfo>(
                BuildEndpoint($"{ApiVersions.MarketData.Prices}/prices?AssetType={assetType}&Uic={uic}"));
        }

        public async Task<string> SubscribeToPricesAsync(string assetType, int uic, int? refreshRate = null)
        {
            var request = new SubscriptionRequest
            {
                Arguments = new { AssetType = assetType, Uic = uic },
                RefreshRate = refreshRate
            };

            return await _streamingConnection.CreateSubscriptionAsync<PriceInfo>(request);
        }

        public async Task<MarketDepth> GetMarketDepthAsync(string assetType, int uic, int depth = 10)
        {
            return await Client.GetAsync<MarketDepth>(
                BuildEndpoint($"{ApiVersions.MarketData.Depth}/depth?AssetType={assetType}&Uic={uic}&Depth={depth}"));
        }

        public async Task<string> SubscribeToMarketDepthAsync(string assetType, int uic, int depth = 10, int? refreshRate = null)
        {
            var request = new SubscriptionRequest
            {
                Arguments = new { AssetType = assetType, Uic = uic, Depth = depth },
                RefreshRate = refreshRate
            };

            return await _streamingConnection.CreateSubscriptionAsync<MarketDepth>(request);
        }

        public async Task<HistoricalPrices> GetHistoricalPricesAsync(
            string assetType,
            int uic,
            string horizon,
            DateTime? from = null,
            DateTime? to = null,
            int? count = null)
        {
            var endpoint = BuildEndpoint($"{ApiVersions.MarketData.History}/history?AssetType={assetType}&Uic={uic}&Horizon={horizon}");

            if (from.HasValue)
                endpoint += $"&From={from.Value:O}";
            if (to.HasValue)
                endpoint += $"&To={to.Value:O}";
            if (count.HasValue)
                endpoint += $"&Count={count.Value}";

            return await Client.GetAsync<HistoricalPrices>(endpoint);
        }

        public async Task<OptionsChain> GetOptionsChainAsync(int uic, DateTime expiryDate, string optionRootId = null)
        {
            var endpoint = BuildEndpoint($"{ApiVersions.MarketData.Options}/options/chain?Uic={uic}&ExpiryDate={expiryDate:yyyy-MM-dd}");

            if (!string.IsNullOrEmpty(optionRootId))
                endpoint += $"&OptionRootId={optionRootId}";

            return await Client.GetAsync<OptionsChain>(endpoint);
        }

        public async Task<string> SubscribeToOptionsChainAsync(int uic, DateTime expiryDate, string optionRootId = null, int? refreshRate = null)
        {
            var request = new SubscriptionRequest
            {
                Arguments = new { Uic = uic, ExpiryDate = expiryDate, OptionRootId = optionRootId },
                RefreshRate = refreshRate
            };

            return await _streamingConnection.CreateSubscriptionAsync<OptionsChain>(request);
        }

        public async Task<TradeMessage[]> GetTradeMessagesAsync(DateTime from, DateTime to, string priority = null)
        {
            var endpoint = BuildEndpoint($"{ApiVersions.MarketData.Messages}/messages?From={from:O}&To={to:O}");

            if (!string.IsNullOrEmpty(priority))
                endpoint += $"&Priority={priority}";

            return await Client.GetAsync<TradeMessage[]>(endpoint);
        }

        public async Task<string> SubscribeToTradeMessagesAsync(string priority = null)
        {
            var request = new SubscriptionRequest
            {
                Arguments = new { Priority = priority }
            };

            return await _streamingConnection.CreateSubscriptionAsync<TradeMessage>(request);
        }

        public async Task<HistoricalPrices> GetIntradayTicksAsync(string assetType, int uic, DateTime from, DateTime to, int? pageSize = null)
        {
            var endpoint = BuildEndpoint($"{ApiVersions.MarketData.Ticks}/ticks?AssetType={assetType}&Uic={uic}&From={from:O}&To={to:O}");

            if (pageSize.HasValue)
                endpoint += $"&PageSize={pageSize.Value}";

            return await Client.GetAsync<HistoricalPrices>(endpoint);
        }

        public async Task<string> GetTradeLevelStatusAsync(string assetType, int uic)
        {
            return await Client.GetAsync<string>(
                BuildEndpoint($"{ApiVersions.MarketData.TradeLevel}/tradelevel?AssetType={assetType}&Uic={uic}"));
        }

        public async Task<string> SubscribeToTradeLevelStatusAsync(string assetType, int uic)
        {
            var request = new SubscriptionRequest
            {
                Arguments = new { AssetType = assetType, Uic = uic }
            };

            return await _streamingConnection.CreateSubscriptionAsync<string>(request);
        }
    }
}
