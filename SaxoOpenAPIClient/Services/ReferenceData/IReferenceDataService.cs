using System.Threading.Tasks;
using SaxoOpenAPIClient.Services.ReferenceData.Models;

namespace SaxoOpenAPIClient.Services.ReferenceData
{
    public interface IReferenceDataService : ISaxoService
    {
        Task<InstrumentDetails> GetInstrumentDetailsAsync(int uic, string assetType);
        Task<InstrumentSearch> SearchInstrumentsAsync(string keywords, string assetTypes);
        Task<ExchangeList> GetExchangesAsync();
        Task<CurrencyPairs> GetCurrencyPairsAsync();
        Task<FuturesSpaces> GetFuturesSpacesAsync();
        Task<OptionRootList> GetOptionRootsAsync(string assetType);
        Task<ContractOptionChain> GetOptionChainAsync(int uic, string assetType);
    }
}
