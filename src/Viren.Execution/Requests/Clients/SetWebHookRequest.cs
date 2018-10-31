namespace Viren.Execution.Requests.Clients
{
    public class SetWebHookRequest
    {
        public string Url { get; set; }
        public string TokenEndpoint { get; set; }
        public string Audience { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public int BatchSize { get; set; }
    }

    public class SetWebHookResponse
    {
    }
}