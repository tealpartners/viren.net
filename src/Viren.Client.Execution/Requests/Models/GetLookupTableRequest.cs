using Newtonsoft.Json.Linq;

namespace Viren.Client.Execution.Requests.Models
{
    public class GetLookupTableRequest
    {
        public string Id { get; set; }

        public string Project { get; set; }

        public string Model { get; set; }

        public int Version { get; set; }

        public int? Revision { get; set; }
    }

    public class GetLookupTableResponse
    {
        public JArray Result { get; set; }
    }
}