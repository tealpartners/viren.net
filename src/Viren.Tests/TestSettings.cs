namespace Viren.Tests
{
    public class TestSettings
    {
        public string apiHostName { get; set; }
        public string clientSecret { get; set; }

        public override string ToString()
        {
            return $"{apiHostName} {clientSecret}";
        }
    }
}