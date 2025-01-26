using System.Threading.Tasks;
using SaxoOpenAPIClient.Services.Trading.Models;

namespace SaxoOpenAPIClient.Services.Trading
{
    public interface IOptionsChainService : ISaxoService
    {
        Task<OptionChain> GetOptionChainAsync(int uic, string assetType);
        Task<OptionChainSubscription> SubscribeToOptionChainAsync(int uic, string assetType);
        Task<OptionStrikes> GetOptionStrikesAsync(int uic, string assetType);
        Task<OptionExpiryDates> GetOptionExpiryDatesAsync(int uic, string assetType);
        Task<OptionMarginImpact> GetMarginImpactAsync(OptionMarginRequest request);
    }
}
