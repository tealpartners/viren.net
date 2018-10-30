using System;

namespace Viren.Client.Execution
{
    public class VirenOptions
    {
        public string BaseUrl { get; set; }
        public string Authority { get; set; }
        public string Audience { get; set; } = "https://tealpartners.com/calculation/api";
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}