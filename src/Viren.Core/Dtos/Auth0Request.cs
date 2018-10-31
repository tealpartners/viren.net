namespace Viren.Core.Dtos
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
#pragma warning disable 649
        public string AccessToken;
#pragma warning restore 649
    }
}