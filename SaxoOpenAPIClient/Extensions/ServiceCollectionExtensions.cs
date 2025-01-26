using System;
using Microsoft.Extensions.DependencyInjection;
using SaxoOpenAPIClient.Authentication;
using SaxoOpenAPIClient.Services;

namespace SaxoOpenAPIClient.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSaxoClient(
            this IServiceCollection services,
            Action<SaxoClientOptions> configureOptions)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            if (configureOptions == null) throw new ArgumentNullException(nameof(configureOptions));

            services.Configure(configureOptions);

            var options = new SaxoClientOptions();
            configureOptions(options);

            services.AddHttpClient<ISaxoClient, SaxoClient>(client =>
            {
                client.BaseAddress = new Uri(options.BaseUrl);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            })
            .AddHttpMessageHandler(() => new SaxoAuthenticationHandler(options));

            // Register service factory
            services.AddSingleton<IServiceFactory, ServiceFactory>();

            // Register all Saxo Bank API services
            RegisterSaxoServices(services);

            return services;
        }

        private static void RegisterSaxoServices(IServiceCollection services)
        {
            // Register all service interfaces and their implementations
            // This allows for easy dependency injection of any service
            var assembly = typeof(ServiceCollectionExtensions).Assembly;
            
            foreach (var type in assembly.GetTypes())
            {
                if (typeof(ISaxoService).IsAssignableFrom(type) && 
                    !type.IsInterface && 
                    !type.IsAbstract)
                {
                    var serviceType = type.GetInterfaces()
                        .FirstOrDefault(i => typeof(ISaxoService).IsAssignableFrom(i) && i != typeof(ISaxoService));
                    
                    if (serviceType != null)
                    {
                        services.AddScoped(serviceType, type);
                    }
                }
            }
        }
    }
}
