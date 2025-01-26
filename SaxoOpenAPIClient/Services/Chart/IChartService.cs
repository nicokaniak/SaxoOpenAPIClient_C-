using System;
using System.Threading.Tasks;
using SaxoOpenAPIClient.Services.Chart.Models;

namespace SaxoOpenAPIClient.Services.Chart
{
    public interface IChartService : ISaxoService
    {
        Task<ChartData> GetChartDataAsync(int uic, string assetType, string horizon, DateTime? from = null, DateTime? to = null);
        Task<ChartSubscription> SubscribeToChartDataAsync(int uic, string assetType);
        Task<Intraday> GetIntradayDataAsync(int uic, string assetType);
        Task<HistoricalPrices> GetHistoricalPricesAsync(int uic, string assetType, string period);
    }
}
