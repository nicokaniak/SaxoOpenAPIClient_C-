using System;
using System.Threading.Tasks;
using SaxoOpenAPIClient.Services.AccountHistory.Models;

namespace SaxoOpenAPIClient.Services.AccountHistory
{
    /// <summary>
    /// Implementation of Saxo Bank account history services
    /// </summary>
    public class AccountHistoryService : BaseSaxoService, IAccountHistoryService
    {
        private readonly IStreamingConnection _streamingConnection;

        public override string BaseEndpoint => ServiceEndpoints.AccountHistory;

        public AccountHistoryService(ISaxoClient client, IStreamingConnection streamingConnection)
            : base(client)
        {
            _streamingConnection = streamingConnection;
        }

        public async Task<AccountPerformance> GetPerformanceAsync(string accountKey, DateTime fromDate, DateTime toDate)
        {
            return await Client.GetAsync<AccountPerformance>(
                BuildEndpoint($"{ApiVersions.AccountHistory.Performance}/performance?AccountKey={accountKey}&FromDate={fromDate:O}&ToDate={toDate:O}"));
        }

        public async Task<AccountStatement> GetStatementAsync(string accountKey, DateTime fromDate, DateTime toDate, string transactionType = null)
        {
            var endpoint = BuildEndpoint($"{ApiVersions.AccountHistory.Statement}/statement?AccountKey={accountKey}&FromDate={fromDate:O}&ToDate={toDate:O}");

            if (!string.IsNullOrEmpty(transactionType))
                endpoint += $"&TransactionType={transactionType}";

            return await Client.GetAsync<AccountStatement>(endpoint);
        }

        public async Task<UnsettledAmount[]> GetUnsettledAmountsAsync(string accountKey, string currency = null)
        {
            var endpoint = BuildEndpoint($"{ApiVersions.AccountHistory.Unsettled}/unsettled?AccountKey={accountKey}");

            if (!string.IsNullOrEmpty(currency))
                endpoint += $"&Currency={currency}";

            return await Client.GetAsync<UnsettledAmount[]>(endpoint);
        }

        public async Task<HistoricalBalance[]> GetHistoricalBalancesAsync(string accountKey, DateTime fromDate, DateTime toDate)
        {
            return await Client.GetAsync<HistoricalBalance[]>(
                BuildEndpoint($"{ApiVersions.AccountHistory.Balance}/balance/history?AccountKey={accountKey}&FromDate={fromDate:O}&ToDate={toDate:O}"));
        }

        public async Task<TradeHistory> GetTradeHistoryAsync(string accountKey, DateTime fromDate, DateTime toDate, string status = null)
        {
            var endpoint = BuildEndpoint($"{ApiVersions.AccountHistory.Trades}/trades/history?AccountKey={accountKey}&FromDate={fromDate:O}&ToDate={toDate:O}");

            if (!string.IsNullOrEmpty(status))
                endpoint += $"&Status={status}";

            return await Client.GetAsync<TradeHistory>(endpoint);
        }

        public async Task<string> SubscribeToPerformanceAsync(string accountKey, int? refreshRate = null)
        {
            var request = new SubscriptionRequest
            {
                Arguments = new { AccountKey = accountKey },
                RefreshRate = refreshRate
            };

            return await _streamingConnection.CreateSubscriptionAsync<AccountPerformance>(request);
        }

        public async Task<string> SubscribeToStatementAsync(string accountKey, int? refreshRate = null)
        {
            var request = new SubscriptionRequest
            {
                Arguments = new { AccountKey = accountKey },
                RefreshRate = refreshRate
            };

            return await _streamingConnection.CreateSubscriptionAsync<AccountStatement>(request);
        }

        public async Task<string> SubscribeToUnsettledAmountsAsync(string accountKey, int? refreshRate = null)
        {
            var request = new SubscriptionRequest
            {
                Arguments = new { AccountKey = accountKey },
                RefreshRate = refreshRate
            };

            return await _streamingConnection.CreateSubscriptionAsync<UnsettledAmount[]>(request);
        }

        public async Task<string> SubscribeToHistoricalBalancesAsync(string accountKey, int? refreshRate = null)
        {
            var request = new SubscriptionRequest
            {
                Arguments = new { AccountKey = accountKey },
                RefreshRate = refreshRate
            };

            return await _streamingConnection.CreateSubscriptionAsync<HistoricalBalance[]>(request);
        }
    }
}
