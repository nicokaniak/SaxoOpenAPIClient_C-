using System.Threading.Tasks;
using SaxoOpenAPIClient.Services.ClientManagement.Models;

namespace SaxoOpenAPIClient.Services.ClientManagement
{
    public interface IClientManagementService : ISaxoService
    {
        Task<ClientInfo> GetClientInfoAsync(string clientKey);
        Task<ClientDetails> GetClientDetailsAsync(string clientKey);
        Task<ClientSettings> GetClientSettingsAsync(string clientKey);
        Task UpdateClientSettingsAsync(string clientKey, ClientSettings settings);
        Task<ClientUsers> GetUsersAsync(string clientKey);
        Task<MarginOverview> GetMarginOverviewAsync(string clientKey);
        Task<ClientAccounts> GetClientAccountsAsync(string clientKey);
    }
}
