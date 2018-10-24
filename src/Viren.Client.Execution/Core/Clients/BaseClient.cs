using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Viren.Client.Execution.Core.Dtos;
using Viren.Client.Execution.Core.Serialization;
using Viren.Client.Execution.Requests;
using Environment = Viren.Client.Execution.Core.Enums.Environment;

namespace Viren.Client.Execution.Core.Clients
{
    public abstract class BaseClient
    {
        private readonly Auth0Client _auth0Client;


        private readonly HttpClient _httpClient;
        private readonly JsonSerializerSettings _jsonSerializerSettings = new VirenNetSerializerSettings();
        protected string _virenDomain;
        internal string Auth0Domain;
        internal string PublicKey;
        internal string SecretKey;

        protected BaseClient(string publicKey, string secretKey, string virenDomain, string auth0Domain)
        {
            PublicKey = publicKey;
            SecretKey = secretKey;
            _virenDomain = virenDomain;
            Auth0Domain = auth0Domain;

            SetHttpFactory(() => new HttpClient());
            _auth0Client = new Auth0Client(this);

            _httpClient = GetHttpClient();
            _httpClient.BaseAddress = new Uri(_virenDomain);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.Timeout = new TimeSpan(0, 0, 5);
        }

        protected BaseClient(string publicKey, string secretKey, string domain, Environment environment) : this(publicKey, secretKey, domain, GetAuth0Domain(environment))
        {
        }

        internal Func<HttpClient> GetHttpClient { get; private set; }

        protected static string GetAuth0Domain(Environment environment)
        {
            switch (environment)
            {
                case Environment.Production:
                    return "https://teal-calculation.eu.auth0.com";
                case Environment.Acceptance:
                    return "https://teal-calculation-acc.eu.auth0.com";
                case Environment.Develop:
                    return "https://teal-calculation-test.eu.auth0.com";
                case Environment.Local:
                    return "https://teal-calculation-dev.eu.auth0.com";
                default:
                    throw new ArgumentOutOfRangeException(nameof(environment), environment, null);
            }
        }

        private void SetHttpFactory(Func<HttpClient> factory)
        {
            GetHttpClient = factory;
        }

        internal Task<TResponse> Post<TRequest, TResponse>(string url, TRequest request) where TRequest : class
        {
            return Send<TRequest, TResponse>(HttpMethod.Post, url, request);
        }

        internal Task<TResponse> Delete<TRequest, TResponse>(string url, TRequest request) where TRequest : class
        {
            return Send<TRequest, TResponse>(HttpMethod.Delete, url, request);
        }

        internal Task<TResponse> Get<TResponse>(string url)
        {
            return Send<object, TResponse>(HttpMethod.Get, url);
        }


        private async Task<TResponse> Send<TRequest, TResponse>(HttpMethod httpMethod, string url, TRequest request = null) where TRequest : class
        {
            var requestMessage = new HttpRequestMessage(httpMethod, new Uri(_virenDomain + url));

            if (httpMethod != HttpMethod.Get) requestMessage.Content = CreateHttpContent(request, _jsonSerializerSettings);

            var accessToken = _auth0Client.GetAccessToken();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await _httpClient.SendAsync(requestMessage).ConfigureAwait(false);
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                var newToken = _auth0Client.Refresh(accessToken);
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", newToken);
                response = await _httpClient.SendAsync(requestMessage).ConfigureAwait(false);
            }

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                return JsonConvert.DeserializeObject<TResponse>(responseString, _jsonSerializerSettings);
            }

            var content = response.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            throw new Exception(content);
        }

        internal StringContent CreateHttpContent(object request, JsonSerializerSettings jsonSerializerSettings)
        {
            var json = JsonConvert.SerializeObject(request, jsonSerializerSettings);
            var httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
            return httpContent;
        }

        internal string BuildUrl(IProject request) => request.Project;
        internal string BuildUrl(IProjectModel request) => BuildUrl((IProject) request) + "/" + request.Model;
        internal string BuildUrl(IProjectModelVersion request) => BuildUrl((IProjectModel) request) + "/" + request.Version;
        internal string BuildUrl(IProjectModelVersionRevision request) => BuildUrl((IProjectModelVersion) request) + "/" + (request.Revision.HasValue ? request.Revision.Value.ToString() : "null");
    }
}