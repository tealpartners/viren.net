using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Viren.Core.Authentication
{
    public class RefreshTokenHandler : DelegatingHandler
    {
        private readonly AccessTokenCache _accessTokenCache;

        public RefreshTokenHandler(AccessTokenCache accessTokenCache)
        {
            _accessTokenCache = accessTokenCache;
        }

        public static RefreshTokenHandler CreateFallback(AccessTokenCache accessTokenCache)
        {
            return new RefreshTokenHandler(accessTokenCache);
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                var accessToken = await _accessTokenCache.GetAccessToken(false, cancellationToken).ConfigureAwait(false);

                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                var response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

                if (response.StatusCode != HttpStatusCode.Unauthorized) return response;

                accessToken = await _accessTokenCache.GetAccessToken(true, cancellationToken).ConfigureAwait(false);

                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
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