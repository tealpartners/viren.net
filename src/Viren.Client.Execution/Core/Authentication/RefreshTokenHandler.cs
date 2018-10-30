using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Viren.Client.Execution.Core.Authentication
{
    internal class RefreshTokenHandler : DelegatingHandler
    {
        private readonly AccessTokenCache _accessTokenCache;

        private RefreshTokenHandler(AccessTokenCache accessTokenCache, object nothing) : base(new HttpClientHandler())
        {
            _accessTokenCache = accessTokenCache;
        }

        public RefreshTokenHandler(AccessTokenCache accessTokenCache)
        {
            _accessTokenCache = accessTokenCache;
        }

        internal static RefreshTokenHandler CreateFallback(AccessTokenCache accessTokenCache)
        {
            return new RefreshTokenHandler(accessTokenCache, null);
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var accessToken = await _accessTokenCache.GetAccessToken(false, cancellationToken).ConfigureAwait(false);
            ;
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

            if (response.StatusCode != HttpStatusCode.Unauthorized) return response;

            accessToken = await _accessTokenCache.GetAccessToken(true, cancellationToken).ConfigureAwait(false);

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}