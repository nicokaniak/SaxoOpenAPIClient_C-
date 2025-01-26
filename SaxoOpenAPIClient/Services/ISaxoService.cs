using System.Threading.Tasks;

namespace SaxoOpenAPIClient.Services
{
    /// <summary>
    /// Base interface for all Saxo Bank API services
    /// </summary>
    public interface ISaxoService
    {
        /// <summary>
        /// Gets the base endpoint for this service
        /// </summary>
        string BaseEndpoint { get; }
    }

    /// <summary>
    /// Generic service interface with common CRUD operations
    /// </summary>
    public interface ISaxoService<TRequest, TResponse> : ISaxoService
        where TRequest : class
        where TResponse : class
    {
        Task<TResponse> GetAsync(string endpoint);
        Task<TResponse> CreateAsync(string endpoint, TRequest request);
        Task<TResponse> UpdateAsync(string endpoint, TRequest request);
        Task DeleteAsync(string endpoint);
    }
}
