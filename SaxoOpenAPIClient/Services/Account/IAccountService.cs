using System;
using System.Threading.Tasks;
using SaxoOpenAPIClient.Services.Account.Models;

namespace SaxoOpenAPIClient.Services.Account
{
    public interface IAccountService : ISaxoService
    {
        Task<AccountHistory> GetAccountHistoryAsync(string accountKey, DateTime from, DateTime to);
        Task<AccountBalance> GetBalanceAsync(string accountKey);
        Task<AccountDetails> GetAccountDetailsAsync(string accountKey);
        Task<AccountList> GetAccountsAsync();
        Task<AccountSubscriptionInfo> SubscribeToAccountUpdatesAsync(string accountKey);
    }
}
