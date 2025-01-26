using System.Threading.Tasks;
using SaxoOpenAPIClient.Services.Market.Models;

namespace SaxoOpenAPIClient.Services.Market
{
    public interface IMarketService : ISaxoService
    {
        Task<MarketOverview> GetMarketOverviewAsync(string assetType, string exchange = null);
        Task<MarketDepth> GetMarketDepthAsync(int uic, string assetType);
        Task<InfoPrices> GetInfoPricesAsync(int[] uics, string[] assetTypes);
        Task<MarketSubscription> SubscribeToMarketDataAsync(int uic, string assetType);
        Task<TradingSchedule> GetTradingScheduleAsync(string exchange, string assetType);
        Task<MarketNews> GetMarketNewsAsync(string language = "en");
    }
}
