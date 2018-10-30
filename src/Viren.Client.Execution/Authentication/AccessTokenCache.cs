using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Viren.Client.Execution.Authentication
{
    class AccessTokenCache
    {
        private readonly Auth0TokenClient _auth0TokenClient;
        private readonly VirenOptions _virenConfig;
        private static readonly TimeSpan LockTimeout = TimeSpan.FromSeconds(2);
        private readonly SemaphoreSlim _lock = new SemaphoreSlim(1, 1);
        private string _accessToken;

        private AccessTokenCache(Auth0TokenClient auth0TokenClient, VirenOptions virenConfig)
        {
            _auth0TokenClient = auth0TokenClient;
            _virenConfig = virenConfig;
        }

        public static AccessTokenCache CreateFallback(Auth0TokenClient auth0TokenClient, VirenOptions virenConfig) 
            => new AccessTokenCache(auth0TokenClient, virenConfig);
        public AccessTokenCache(Auth0TokenClient auth0TokenClient, IOptions<VirenOptions> virenConfig)
        :this(auth0TokenClient, virenConfig.Value)
        {
        }

        public async Task<string> GetAccessToken(bool refresh, CancellationToken cancellationToken)
        {
            var currentBeforeLock = _accessToken;
            if (!await _lock.WaitAsync(LockTimeout, cancellationToken))
            {
                throw new Exception($"Lock timeout not released within {LockTimeout} in {typeof(AccessTokenCache)}");                
            }

            try
            {
                var current = _accessToken;
                // Access token has been refreshed or current is set and refresh is false
                if (!string.Equals(current, currentBeforeLock) ||
                    (refresh == false && !string.IsNullOrEmpty(current)))
                {
                    return current;
                }
                
                _accessToken = current = await _auth0TokenClient.GetAccessToken(
                    _virenConfig.ClientId, 
                    _virenConfig.ClientSecret, 
                    _virenConfig.Audience);
                return current;
            }
            finally
            {
                _lock.Release();
            }
                
        }
    }
}