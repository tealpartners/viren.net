using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Viren.Client.Execution.Requests.Models
{
    public class GetLookupTablesRequest
    {
        public string Project { get; set; }

        public string Model { get; set; }

        public int Version { get; set; }

        public int? Revision { get; set; }

        public string[] GlobalIds { get; set; }
    }

    public class GetLookupTablesResponse
    {
        public Dictionary<string, JArray> Result { get; set; }
    }
}