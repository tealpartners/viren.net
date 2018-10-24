using Newtonsoft.Json.Linq;
using Viren.Client.Execution.Core.Dtos;

namespace Viren.Client.Execution.Requests.Models
{
    public class GetLookupTableRequest: IProjectModelVersionRevision
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