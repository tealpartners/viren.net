using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Viren.Client.Execution.Authentication
{
    class RefreshTokenHandler : DelegatingHandler
    {
        private readonly AccessTokenCache _accessTokenCache;

        private RefreshTokenHandler(AccessTokenCache accessTokenCache, object nothing) : base (new HttpClientHandler())
        {
            _accessTokenCache = accessTokenCache;
        }
        public RefreshTokenHandler(AccessTokenCache accessTokenCache)
        {
            _accessTokenCache = accessTokenCache;
        }

        public static RefreshTokenHandler CreateFallback(AccessTokenCache accessTokenCache)
        {
            return new RefreshTokenHandler(accessTokenCache, null);
        }
        
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var accessToken = await _accessTokenCache.GetAccessToken(false, cancellationToken);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var response = await base.SendAsync(request, cancellationToken);

            if (response.StatusCode != HttpStatusCode.Unauthorized)
            {
                return response;
            }
            
            accessToken = await _accessTokenCache.GetAccessToken(true, cancellationToken);

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            return await base.SendAsync(request, cancellationToken);
        }
    }
}