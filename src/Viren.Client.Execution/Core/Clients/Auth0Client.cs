using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using Newtonsoft.Json;
using Viren.Client.Execution.Core.Dtos;
using Viren.Client.Execution.Core.Serialization;

namespace Viren.Client.Execution.Core.Clients
{
    internal interface IAuth0Client
    {
        string GetAccessToken();
        string Refresh(string previousAccessToken);
    }

    internal class Auth0Client : IAuth0Client
    {
        private readonly object _accessTokenLock = new object();

        private readonly BaseClient _baseClient;
        private readonly HttpClient _client;
        private readonly JsonSerializerSettings _jsonSerializerSettings = new Auth0SerializerSettings();

        private volatile Lazy<string> _accessToken;

        internal Auth0Client(BaseClient baseClient)
        {
            _accessToken = new Lazy<string>(RequestAccessToken, LazyThreadSafetyMode.ExecutionAndPublication);
            _baseClient = baseClient;

            _client = _baseClient.GetHttpClient();
            _client.BaseAddress = new Uri(_baseClient.Auth0Domain);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.Timeout = new TimeSpan(0, 0, 5);
        }


        public string GetAccessToken()
        {
            return _accessToken.Value;
        }

        public string Refresh(string previous)
        {
            //We only want to refresh the access token if it is the previous access token. If the token
            //has changed, the access token is already refreshed and we can return the new access token.
            if (_accessToken.Value != previous) return _accessToken.Value;

            lock (_accessTokenLock)
            {
                if (_accessToken.Value != previous) return _accessToken.Value;

                _accessToken = new Lazy<string>(RequestAccessToken, LazyThreadSafetyMode.ExecutionAndPublication);

                return _accessToken.Value;
            }
        }

        public string RequestAccessToken()
        {
            var request = new Auth0Request
            {
                Audience = "https://tealpartners.com/calculation/api",
                GrantType = "client_credentials",
                ClientId = _baseClient.PublicKey,
                ClientSecret = _baseClient.SecretKey
            };

            var httpContent = _baseClient.CreateHttpContent(request, _jsonSerializerSettings);


            var response = _client.PostAsync("oauth/token", httpContent).ConfigureAwait(false).GetAwaiter().GetResult();

            if (!response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();
                throw new InvalidOperationException($"Could not get access_token '{content}'. Response code: {response.StatusCode}");
            }

            var responseString = response.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            var result = JsonConvert.DeserializeObject<Auth0Response>(responseString, _jsonSerializerSettings);

            if (result != null) return result.AccessToken;

            throw new InvalidOperationException($"Could not parse access_token, calculateResult is null. Response code: {response.StatusCode}");
        }
    }
}