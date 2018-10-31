using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Viren.Core;
using Viren.Core.Authentication;
using Viren.Execution.Clients;

namespace Viren.Execution.Extensions.DependencyInjection
{
    class VirenRegistrations
    {
        private readonly IServiceCollection _services;

        public VirenRegistrations(IServiceCollection services)
        {
            _services = services;
        }

        public VirenRegistrations AddVirenExecutionOptions(Action<VirenExecutionOptions> configureOptions)
        {
            _services.AddOptions<VirenExecutionOptions>().Configure(configureOptions);
            return this;
        }

        public VirenRegistrations AddOidcClient(Action<IHttpClientBuilder> extendOidcHttpClient)
        {
            var oidcClientBuilder = _services.AddHttpClient("viren_oidc", (services, client) =>
            {
                var options = services.GetService<IOptions<VirenExecutionOptions>>().Value;
                client.BaseAddress = new Uri(options.Authority, UriKind.Absolute);
            }).AddTypedClient<Auth0TokenClient>();

            extendOidcHttpClient?.Invoke(oidcClientBuilder);
            return this;
        }

        public VirenRegistrations AddAccessTokenCache()
        {
            _services.AddSingleton(x => 
                new AccessTokenCache(
                    x.GetRequiredService<Auth0TokenClient>(),
                    x.GetRequiredService<IOptions<VirenExecutionOptions>>().Value));
            return this;
        }

        public VirenRegistrations AddRefreshTokenHandler()
        {
            _services.AddTransient<RefreshTokenHandler>();
            return this;
        }

        public VirenRegistrations AddVirenExecutionClient(Action<IHttpClientBuilder> extendVirenHttpClient)
        {
            var virenClientBuilder = _services.AddHttpClient("viren_client", (services, client) =>
                {
                    var options = services.GetService<IOptions<VirenExecutionOptions>>().Value;
                    client.BaseAddress = new Uri(options.BaseUrl);
                })
                .AddHttpMessageHandler<RefreshTokenHandler>()
                .AddTypedClient<IVirenExecutionClient, VirenExecutionClient>();

            extendVirenHttpClient?.Invoke(virenClientBuilder);
            return this;
        }
    }
}