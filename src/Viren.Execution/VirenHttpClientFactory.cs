using System;
using System.Net.Http;
using Viren.Core;
using Viren.Core.Authentication;
using Viren.Core.Helpers;

namespace Viren.Execution
{
    /// <summary>
    /// http client factory that returns http client with Auth0 authorization handling
    /// </summary>
    public class VirenHttpClientFactory
    {
        private static AccessTokenCache _accesTokenCache = null;
        
        public static HttpClient Create(string publicKey, string secretKey, string virenDomain, string auth0Domain)
        {
            return Create(new VirenExecutionOptions {ClientId = publicKey, ClientSecret = secretKey, Authority = auth0Domain, BaseUrl = virenDomain});
        }

        public static HttpClient Create(string publicKey, string secretKey, Viren.Core.Enums.Environment environment)

        {
            return Create(new VirenExecutionOptions().UseEnvironment(environment, publicKey, secretKey));
        }


        /// <summary>
        /// using this factory will asure AccessTokenCache messagehandler is instantiated only once
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public static HttpClient Create(VirenExecutionOptions options)
        {
            if (_accesTokenCache == null)
            {
                var auth0HttpClient = new HttpClient {BaseAddress = new Uri(options.Authority)};

                var auth0TokenClient = new Auth0TokenClient(auth0HttpClient);
                _accesTokenCache = new AccessTokenCache(auth0TokenClient, options);                
            }

            var refreshTokenHandler = RefreshTokenHandler.CreateFallback(_accesTokenCache);


            var virenHttpClient = new HttpClient(refreshTokenHandler)
            {
                BaseAddress = new Uri(options.BaseUrl)
            };
            return virenHttpClient;
        }
    }
}