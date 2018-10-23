using System.Collections.Generic;
using Viren.Client.Execution.Dtos;

namespace Viren.Client.Execution.Requests.InteractiveRun
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