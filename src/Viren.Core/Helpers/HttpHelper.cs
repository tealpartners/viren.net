using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Viren.Core.Serialization;

namespace Viren.Core.Helpers
{
    public static class HttpHelper
    {
        private static readonly JsonSerializerSettings JsonSerializerSettings = new VirenNetSerializerSettings();

        public static Task<TResponse> Post<TRequest, TResponse>(this HttpClient client, string url, TRequest request) where TRequest : class
        {
            return client.Send<TRequest, TResponse>(HttpMethod.Post, url, request);
        }

        public static Task<TResponse> Delete<TRequest, TResponse>(this HttpClient client, string url, TRequest request) where TRequest : class
        {
            return client.Send<TRequest, TResponse>(HttpMethod.Delete, url, request);
        }

        public static Task<TResponse> Get<TResponse>(this HttpClient client, string url)
        {
            return client.Send<object, TResponse>(HttpMethod.Get, url);
        }

        public static Task<TResponse> Put<TRequest, TResponse>(this HttpClient client, string url, TRequest request) where TRequest : class
        {
            return client.Send<TRequest, TResponse>(HttpMethod.Put, url, request);
        }

        private static async Task<TResponse> Send<TRequest, TResponse>(this HttpClient client, HttpMethod httpMethod, string url, TRequest request = null) where TRequest : class
        {
            var requestMessage = new HttpRequestMessage(httpMethod, url);

            if (httpMethod != HttpMethod.Get) requestMessage.Content = request.ToStringContent(JsonSerializerSettings);

            var response = await client.SendAsync(requestMessage).ConfigureAwait(false);

            var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<TResponse>(responseString, JsonSerializerSettings);
            }
            
            if (string.IsNullOrEmpty(responseString))
            {
                throw new Exception(response.ToString());
            }
            
            throw new Exception(responseString);
        }
    }
}