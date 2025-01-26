using System;
using System.Collections.Concurrent;
using Microsoft.Extensions.DependencyInjection;

namespace SaxoOpenAPIClient.Services
{
    /// <summary>
    /// Factory for creating Saxo Bank API service instances
    /// </summary>
    public interface IServiceFactory
    {
        T GetService<T>() where T : ISaxoService;
    }

    /// <summary>
    /// Default implementation of IServiceFactory
    /// </summary>
    public class ServiceFactory : IServiceFactory
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ConcurrentDictionary<Type, object> _services;

        public ServiceFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            _services = new ConcurrentDictionary<Type, object>();
        }

        public T GetService<T>() where T : ISaxoService
        {
            return (T)_services.GetOrAdd(typeof(T), _ => 
                _serviceProvider.GetRequiredService<T>());
        }
    }
}
