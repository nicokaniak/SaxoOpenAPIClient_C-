using System.Threading.Tasks;
using SaxoOpenAPIClient.Services.Trading.Models;

namespace SaxoOpenAPIClient.Services.Trading
{
    public interface IAllocationKeyService : ISaxoService
    {
        Task<AllocationKeyList> GetAllocationKeysAsync();
        Task<AllocationKey> CreateAllocationKeyAsync(AllocationKeyRequest request);
        Task<AllocationKey> UpdateAllocationKeyAsync(string keyId, AllocationKeyRequest request);
        Task DeleteAllocationKeyAsync(string keyId);
        Task<AllocationKeyDetails> GetAllocationKeyDetailsAsync(string keyId);
    }
}
