using System;
using System.Threading.Tasks;

namespace SaxoOpenAPIClient.Services
{
    /// <summary>
    /// Base implementation for all Saxo Bank API services
    /// </summary>
    public abstract class BaseSaxoService : ISaxoService
    {
        protected readonly ISaxoClient Client;

        protected BaseSaxoService(ISaxoClient client)
        {
            Client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public abstract string BaseEndpoint { get; }

        protected string BuildEndpoint(string relativePath)
        {
            return $"{BaseEndpoint.TrimEnd('/')}/{relativePath.TrimStart('/')}";
        }
    }

    /// <summary>
    /// Generic base implementation with common CRUD operations
    /// </summary>
    public abstract class BaseSaxoService<TRequest, TResponse> : BaseSaxoService, ISaxoService<TRequest, TResponse>
        where TRequest : class
        where TResponse : class
    {
        protected BaseSaxoService(ISaxoClient client) : base(client) { }

        public virtual async Task<TResponse> GetAsync(string endpoint)
        {
            return await Client.GetAsync<TResponse>(BuildEndpoint(endpoint));
        }

        public virtual async Task<TResponse> CreateAsync(string endpoint, TRequest request)
        {
            return await Client.PostAsync<TRequest, TResponse>(BuildEndpoint(endpoint), request);
        }

        public virtual async Task<TResponse> UpdateAsync(string endpoint, TRequest request)
        {
            return await Client.PutAsync<TRequest, TResponse>(BuildEndpoint(endpoint), request);
        }

        public virtual async Task DeleteAsync(string endpoint)
        {
            await Client.DeleteAsync(BuildEndpoint(endpoint));
        }
    }
}
