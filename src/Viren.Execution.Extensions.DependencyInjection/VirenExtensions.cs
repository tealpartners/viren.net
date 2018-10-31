using System;
using Microsoft.Extensions.DependencyInjection;
using Viren.Core;
using Viren.Core.Helpers;
using Environment = Viren.Core.Enums.Environment;

namespace Viren.Execution.Extensions.DependencyInjection
{
    public static class VirenExtensions
    {
        public static IServiceCollection AddVirenExecution(this IServiceCollection serviceCollection, Environment environment,
            string clientId, string clientSecret)
        {
            return serviceCollection.AddVirenExecution(ops => ops.UseEnvironment(environment, clientId, clientSecret));
        }
        
        public static IServiceCollection AddVirenExecution(this IServiceCollection serviceCollection, Action<VirenExecutionOptions> configureOptions,
            Action<IHttpClientBuilder> extendOidcHttpClient = null,
            Action<IHttpClientBuilder> extendVirenHttpClient = null)
        {
            new VirenRegistrations(serviceCollection)
                .AddVirenExecutionOptions(configureOptions)
                .AddOidcClient(extendOidcHttpClient)
                .AddAccessTokenCache()
                .AddRefreshTokenHandler()
                .AddVirenExecutionClient(extendVirenHttpClient);

            return serviceCollection;
        }
    }
}
