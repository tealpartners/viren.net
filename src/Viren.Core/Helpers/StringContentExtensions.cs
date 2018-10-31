using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace Viren.Core.Helpers
{
    internal static class StringContentExtensions
    {
        public static StringContent ToStringContent(this object request, JsonSerializerSettings jsonSerializerSettings)
        {
            var json = JsonConvert.SerializeObject(request, jsonSerializerSettings);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}