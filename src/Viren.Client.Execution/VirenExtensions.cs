using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Viren.Client.Execution.Authentication;
using Environment = Viren.Client.Execution.Core.Enums.Environment;

namespace Viren.Client.Execution
{
    public static class VirenExtensions
    {
        public static IServiceCollection AddViren(this IServiceCollection serviceCollection, Environment environment,
            string clientId, string clientSecret)
            => serviceCollection.AddViren(ops => ops.UseEnvironment(environment, clientId, clientSecret));
        public static IServiceCollection AddViren(this IServiceCollection serviceCollection, Action<VirenOptions> configureOptions, 
            Action<IHttpClientBuilder> extendOidcHttpClient = null,
            Action<IHttpClientBuilder> extendVirenHttpClient = null)
        {
            serviceCollection.AddOptions<VirenOptions>().Configure(configureOptions);
            var oidcClientBuilder = serviceCollection.AddHttpClient("viren_oidc", (services, client) =>
            {
                var options = services.GetService<IOptions<VirenOptions>>().Value;
                client.BaseAddress = new Uri(options.Authority, UriKind.Absolute);
            }).AddTypedClient<Auth0TokenClient>();
            
            extendOidcHttpClient?.Invoke(oidcClientBuilder);
            
            serviceCollection.AddSingleton<AccessTokenCache>();
            serviceCollection.AddTransient<RefreshTokenHandler>();
            
            var virenClientBuilder = serviceCollection.AddHttpClient("viren_client", (services, client) =>
                {
                    var options = services.GetService<IOptions<VirenOptions>>().Value;
                    client.BaseAddress = new Uri(options.BaseUrl);
                })
                .AddHttpMessageHandler<RefreshTokenHandler>()
                .AddTypedClient<IVirenClient, VirenClient>();
            
            extendVirenHttpClient?.Invoke(virenClientBuilder);
            
            return serviceCollection;
        }
    }
}