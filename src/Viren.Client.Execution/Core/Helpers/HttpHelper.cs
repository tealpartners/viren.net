using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Viren.Client.Execution.Core.Serialization;

namespace Viren.Client.Execution.Core.Helpers
{
    internal static class HttpHelper
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


        private static async Task<TResponse> Send<TRequest, TResponse>(this HttpClient client, HttpMethod httpMethod, string url, TRequest request = null) where TRequest : class
        {
            var requestMessage = new HttpRequestMessage(httpMethod, url);

            if (httpMethod != HttpMethod.Get) requestMessage.Content = request.ToStringContent(JsonSerializerSettings);

            var response = await client.SendAsync(requestMessage).ConfigureAwait(false);
            ;

            var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (response.IsSuccessStatusCode) return JsonConvert.DeserializeObject<TResponse>(responseString, JsonSerializerSettings);

            throw new Exception(responseString);
        }
    }
}