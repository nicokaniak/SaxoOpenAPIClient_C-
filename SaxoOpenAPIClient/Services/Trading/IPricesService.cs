using System.Threading.Tasks;
using SaxoOpenAPIClient.Services.Trading.Models;

namespace SaxoOpenAPIClient.Services.Trading
{
    public interface IPricesService : ISaxoService
    {
        Task<Price> GetPriceAsync(int uic, string assetType);
        Task<PriceList> GetPricesAsync(int[] uics, string[] assetTypes);
        Task<PriceSubscription> SubscribeToPricesAsync(int[] uics, string[] assetTypes);
        Task<PriceHistory> GetPriceHistoryAsync(int uic, string assetType, string horizon);
        Task<MarginPrices> GetMarginPricesAsync(int[] uics, string[] assetTypes);
    }
}
