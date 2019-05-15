namespace Viren.Tests
{
    public class TestSettings
    {
        public string apiHostName { get; set; }
        public string auth0Domain { get; set; }
        public string auth0TestsClientId { get; set; }
        public string auth0TestsClientSecret { get; set; }

        public override string ToString()
        {
            return $"{apiHostName} {auth0Domain} {auth0TestsClientId} {auth0TestsClientSecret}";
        }
    }
}