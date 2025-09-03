using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Viren.Core.Dtos;

namespace Viren.Execution.Requests.Models
{
    public class GetLookupTableRequest : IProjectModelVersionRevision
    {
        public string Id { get; set; }

        public string Project { get; set; }

        public string Model { get; set; }

        public int Version { get; set; }

        public int? Revision { get; set; }

        public string DraftKey { get; set; }
    }

    public class GetLookupTableResponse
    {
        public GetLookupTableResponse()
        {
            ValidationMessages = new List<ValidationMessage>();
        }

        public JArray Result { get; set; }

        public List<ValidationMessage> ValidationMessages { get; set; }
    }
}