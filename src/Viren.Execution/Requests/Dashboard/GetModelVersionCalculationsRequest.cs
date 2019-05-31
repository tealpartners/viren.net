using System.Collections.Generic;

namespace Viren.Execution.Requests.Dashboard
{
    public class GetModelVersionCalculationsRequest
    {
        public string Project { get; set; }
        public string Model { get; set; }
        public int Version { get; set; }
    }


    public class GetModelVersionCalculationsResponse
    {
        public List<ExecutedCalculationDto> LatestExecutions { get; set; }
    }
}