using System.Threading.Tasks;
using SaxoOpenAPIClient.Services.Trading.Models;

namespace SaxoOpenAPIClient.Services.Trading
{
    public interface IInfoPricesService : ISaxoService
    {
        Task<InfoPrice> GetInfoPriceAsync(int uic, string assetType);
        Task<InfoPriceList> GetInfoPricesAsync(int[] uics, string[] assetTypes);
        Task<InfoPriceSubscription> SubscribeToInfoPricesAsync(int[] uics, string[] assetTypes);
        Task<MarketDepth> GetMarketDepthAsync(int uic, string assetType);
        Task<TradingConditions> GetTradingConditionsAsync(int uic, string assetType);
    }
}
