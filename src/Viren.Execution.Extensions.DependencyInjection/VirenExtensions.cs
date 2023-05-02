using System;
using Microsoft.Extensions.DependencyInjection;
using Viren.Core;
using Viren.Core.Helpers;
using Environment = Viren.Core.Enums.Environment;

namespace Viren.Execution.Extensions.DependencyInjection
{
    public static class VirenExtensions
    {
        public static IServiceCollection AddVirenExecution(this IServiceCollection serviceCollection, Environment environment, string clientSecret, string trustKey = null)
        {
            return serviceCollection.AddVirenExecution(ops => ops.UseEnvironment(environment, clientSecret, trustKey));
        }

        public static IServiceCollection AddVirenExecution(this IServiceCollection serviceCollection, Action<VirenExecutionOptions> configureOptions,
            Action<IHttpClientBuilder> extendVirenHttpClient = null)
        {
            new VirenRegistrations(serviceCollection)
                .AddVirenExecutionOptions(configureOptions)
                .AddAuthenticationHandler()
                .AddVirenExecutionClient(extendVirenHttpClient);

            return serviceCollection;
        }
    }
}