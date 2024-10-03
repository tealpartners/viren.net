using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Viren.Core.Authentication
{
    public class AuthenticationHandler : DelegatingHandler
    {
        private readonly VirenExecutionOptions _virenConfig;

        public AuthenticationHandler(VirenExecutionOptions virenConfig)
        {
            _virenConfig = virenConfig;
        }

        public AuthenticationHandler(VirenExecutionOptions virenConfig, bool withInnerClientHandler): base(new HttpClientHandler())
        {
            _virenConfig = virenConfig;
        }

        public static AuthenticationHandler CreateFallback(VirenExecutionOptions virenConfig)
        {
            //the non DI version needs innerhandler: System.InvalidOperationException : The inner handler has not been assigned.
            //the DI version crashes : System.InvalidOperationException: The 'InnerHandler' property must be null. 'DelegatingHandler' instances provided to 'HttpMessageHandlerBuilder' must not be reused or cached.
            return new AuthenticationHandler(virenConfig, true);
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                if(!string.IsNullOrEmpty(_virenConfig.TrustKey))
                {
                    request.Headers.Add("X-Azure-FDID", _virenConfig.TrustKey);
                }

                request.Headers.Authorization = new AuthenticationHeaderValue("ApiKey", _virenConfig.ClientSecret);
                return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                //if " await base.SendAsync" crashes (eg "the inner handler has not been assigned"), put breakpoint here 
                Console.WriteLine(e);
                throw;
            }
        }
    }
}