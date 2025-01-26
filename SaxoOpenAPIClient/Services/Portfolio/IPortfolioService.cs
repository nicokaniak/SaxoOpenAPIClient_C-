using System.Threading.Tasks;
using SaxoOpenAPIClient.Services.Portfolio.Models;

namespace SaxoOpenAPIClient.Services.Portfolio
{
    public interface IPortfolioService : ISaxoService
    {
        Task<PortfolioSummary> GetPortfolioSummaryAsync(string accountKey);
        Task<PortfolioPositions> GetPositionsAsync(string accountKey);
        Task<PortfolioAllocation> GetAllocationAsync(string accountKey);
        Task<PortfolioPerformance> GetPerformanceAsync(string accountKey);
        Task<PortfolioExposure> GetExposureAsync(string accountKey);
        Task<NetPositions> GetNetPositionsAsync(string accountKey);
    }
}
