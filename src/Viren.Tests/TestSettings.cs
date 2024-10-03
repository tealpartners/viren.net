namespace Viren.Tests
{
    public class TestSettings
    {
        public string ApiHostName { get; set; }
        public string ClientSecret { get; set; }
        public string TrustKey { get; set; }


        public override string ToString()
        {
            return $"{ApiHostName} {ClientSecret} {TrustKey}";
        }
    }
}