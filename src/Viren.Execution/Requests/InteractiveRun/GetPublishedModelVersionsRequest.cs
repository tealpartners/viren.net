using System.Collections.Generic;
using Viren.Execution.Dtos;

namespace Viren.Execution.Requests.InteractiveRun
{
    public class GetPublishedModelVersionsRequest
    {
    }


    public class GetPublishedModelVersionsResponse
    {
        public List<ModelVersionDto> PublishedModelVersions { get; set; }
        public List<ModelVersionDto> DraftModelVersions { get; set; }
    }
}