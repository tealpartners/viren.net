namespace Viren.Client.Execution.Core.Dtos
{
    internal class Auth0Request
    {
        public string Audience;

        public string ClientId;

        public string ClientSecret;
        public string GrantType;
    }

    internal class Auth0Response
    {
        public string AccessToken;
    }
}