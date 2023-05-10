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

        public VirenRegistrations AddAuthenticationHandler()
        {
            // Always create new Message Handler
            _services.AddTransient(provider => new AuthenticationHandler(provider.GetService<IOptions<VirenExecutionOptions>>().Value));
            return this;
        }

        public VirenRegistrations AddVirenExecutionClient(Action<IHttpClientBuilder> extendVirenHttpClient)
        {
            var virenClientBuilder = _services.AddHttpClient("viren_client", (services, client) =>
                {
                    var options = services.GetService<IOptions<VirenExecutionOptions>>().Value;
                    client.BaseAddress = new Uri(options.BaseUrl);
                })
                .AddHttpMessageHandler<AuthenticationHandler>()
                .AddTypedClient<IVirenExecutionClient, ExecutionClient>();

            extendVirenHttpClient?.Invoke(virenClientBuilder);
            return this;
        }
    }
}