using System;
using System.Threading;
using System.Threading.Tasks;

namespace Viren.Core.Authentication
{
    public class AccessTokenCache
    {
        private static readonly TimeSpan LockTimeout = TimeSpan.FromSeconds(2);
        private readonly Auth0TokenClient _auth0TokenClient;
        private readonly SemaphoreSlim _lock = new SemaphoreSlim(1, 1);
        private readonly VirenExecutionOptions _virenConfig;
        private string _accessToken;

        public AccessTokenCache(Auth0TokenClient auth0TokenClient, VirenExecutionOptions virenConfig)
        {
            _auth0TokenClient = auth0TokenClient;
            _virenConfig = virenConfig;
        }

        internal async Task<string> GetAccessToken(bool refresh, CancellationToken cancellationToken)
        {
            var currentBeforeLock = _accessToken;
            if (!await _lock.WaitAsync(LockTimeout, cancellationToken).ConfigureAwait(false)) throw new Exception($"Lock timeout not released within {LockTimeout} in {typeof(AccessTokenCache)}");

            try
            {
                var current = _accessToken;
                // Access token has been refreshed or current is set and refresh is false
                if (!string.Equals(current, currentBeforeLock) ||
                    refresh == false && !string.IsNullOrEmpty(current))
                    return current;

                _accessToken = current = await _auth0TokenClient.GetAccessToken(
                    _virenConfig.ClientId,
                    _virenConfig.ClientSecret,
                    _virenConfig.Audience).ConfigureAwait(false);
                return current;
            }
            finally
            {
                _lock.Release();
            }
        }
    }
}