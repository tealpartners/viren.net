using Viren.Core.Dtos;

namespace Viren.Execution.Requests.Models
{
    public class GetLatestVersionRequest : IProjectModel
    {
        public string Project { get; set; }

        public string Model { get; set; }

        public bool Draft { get; set; }
    }

    public class GetLatestVersionResponse
    {
        public int Version { get; set; }

        public int? Revision { get; set; }
    }
}