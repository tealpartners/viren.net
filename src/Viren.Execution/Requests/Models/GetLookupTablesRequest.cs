using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Viren.Core.Dtos;

namespace Viren.Execution.Requests.Models
{
    public class GetLookupTablesRequest : IProjectModelVersionRevision
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