using Newtonsoft.Json;

namespace Viren.Core.Serialization
{
    public class VirenNetSerializerSettings : JsonSerializerSettings
    {
        public VirenNetSerializerSettings()
        {
            ContractResolver = new CamelCaseExceptDictionaryKeysResolver();
            FloatParseHandling = FloatParseHandling.Decimal;
            DateTimeZoneHandling = DateTimeZoneHandling.Utc;
            DateFormatHandling = DateFormatHandling.IsoDateFormat;
            DateParseHandling = DateParseHandling.DateTimeOffset;
        }
    }
}