using System;
using System.Net.Http;
using Viren.Core;
using Viren.Core.Authentication;
using Viren.Core.Helpers;

namespace Viren.Execution
{
    /// <summary>
    /// http client factory that returns http client with authorization handling
    /// </summary>
    public class VirenHttpClientFactory
    {
        public static HttpClient Create(string secretKey, string virenDomain, string trustKey = null)
        {
            return Create(new VirenExecutionOptions {ClientSecret = secretKey, BaseUrl = virenDomain, TrustKey = trustKey});
        }

        public static HttpClient Create(string secretKey, Viren.Core.Enums.Environment environment)

        {
            return Create(new VirenExecutionOptions().UseEnvironment(environment, secretKey));
        }


        /// <summary>
        /// using this factory will asure AuthenticationHandler is instantiated only once
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public static HttpClient Create(VirenExecutionOptions options)
        {
            var authenticationHandler = AuthenticationHandler.CreateFallback(options);
            
            var virenHttpClient = new HttpClient(authenticationHandler)
            {
                BaseAddress = new Uri(options.BaseUrl)
            };
            return virenHttpClient;
        }
    }
}