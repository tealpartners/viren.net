using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Viren.Client.Execution.Clients.Helpers;
using Viren.Client.Execution.Core;
using Viren.Client.Execution.Core.Dtos;
using Viren.Client.Execution.Core.Serialization;

namespace Viren.Client.Execution.Authentication
{
    class Auth0TokenClient
    {
        private readonly HttpClient _client;
        private readonly Auth0SerializerSettings _jsonSerializerSettings;

        public Auth0TokenClient(HttpClient client)
        {
            _client = client;
            _jsonSerializerSettings = new Auth0SerializerSettings();
        }

        public async Task<string> GetAccessToken(string clientId, string clientSecret, string audience)
        {
            var request = new Auth0Request
            {
                Audience = audience,
                GrantType = "client_credentials",
                ClientId = clientId,
                ClientSecret = clientSecret
            };

            var httpContent = request.ToStringContent(_jsonSerializerSettings);


            var response = await _client.PostAsync("oauth/token", httpContent).ConfigureAwait(false);
            
            var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidOperationException($"Could not get access_token '{responseString}'. Response code: {response.StatusCode}");
            }

            var result = JsonConvert.DeserializeObject<Auth0Response>(responseString, _jsonSerializerSettings);

            if (result != null) return result.AccessToken;

            throw new InvalidOperationException($"Could not parse access_token, calculateResult is null. Response code: {response.StatusCode}");
        }
    }
}