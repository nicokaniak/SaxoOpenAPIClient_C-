using System;
using System.Threading.Tasks;
using SaxoOpenAPIClient.Services.AccountHistory.Models;

namespace SaxoOpenAPIClient.Services.AccountHistory
{
    /// <summary>
    /// Interface for accessing Saxo Bank account history services
    /// </summary>
    public interface IAccountHistoryService : ISaxoService
    {
        /// <summary>
        /// Get account performance metrics
        /// </summary>
        Task<AccountPerformance> GetPerformanceAsync(
            string accountKey,
            DateTime fromDate,
            DateTime toDate);

        /// <summary>
        /// Get account statement
        /// </summary>
        Task<AccountStatement> GetStatementAsync(
            string accountKey,
            DateTime fromDate,
            DateTime toDate,
            string transactionType = null);

        /// <summary>
        /// Get unsettled amounts
        /// </summary>
        Task<UnsettledAmount[]> GetUnsettledAmountsAsync(
            string accountKey,
            string currency = null);

        /// <summary>
        /// Get historical balances
        /// </summary>
        Task<HistoricalBalance[]> GetHistoricalBalancesAsync(
            string accountKey,
            DateTime fromDate,
            DateTime toDate);

        /// <summary>
        /// Get trade history
        /// </summary>
        Task<TradeHistory> GetTradeHistoryAsync(
            string accountKey,
            DateTime fromDate,
            DateTime toDate,
            string status = null);

        /// <summary>
        /// Subscribe to account performance updates
        /// </summary>
        Task<string> SubscribeToPerformanceAsync(
            string accountKey,
            int? refreshRate = null);

        /// <summary>
        /// Subscribe to account statement updates
        /// </summary>
        Task<string> SubscribeToStatementAsync(
            string accountKey,
            int? refreshRate = null);

        /// <summary>
        /// Subscribe to unsettled amounts updates
        /// </summary>
        Task<string> SubscribeToUnsettledAmountsAsync(
            string accountKey,
            int? refreshRate = null);

        /// <summary>
        /// Subscribe to historical balances updates
        /// </summary>
        Task<string> SubscribeToHistoricalBalancesAsync(
            string accountKey,
            int? refreshRate = null);
    }
}
