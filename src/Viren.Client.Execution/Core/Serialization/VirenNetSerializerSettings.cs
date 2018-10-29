using Newtonsoft.Json;

namespace Viren.Client.Execution.Core.Serialization
{
    public class VirenNetSerializerSettings : JsonSerializerSettings
    {
        public VirenNetSerializerSettings()
        {
            ContractResolver = new CamelCaseExceptDictionaryKeysResolver();
            FloatParseHandling = FloatParseHandling.Decimal;
        }
    }
}