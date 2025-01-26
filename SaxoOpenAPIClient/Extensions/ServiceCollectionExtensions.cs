using System;
using Microsoft.Extensions.DependencyInjection;
using SaxoOpenAPIClient.Authentication;

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

            return services;
        }
    }
}
