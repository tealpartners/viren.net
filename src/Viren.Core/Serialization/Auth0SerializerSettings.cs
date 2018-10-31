using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Viren.Core.Serialization
{
    public class Auth0SerializerSettings : JsonSerializerSettings
    {
        public Auth0SerializerSettings()
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            };
            Formatting = Formatting.Indented;
        }
    }
}