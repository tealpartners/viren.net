using System.Collections.Generic;

namespace Viren.Execution.Requests.Dashboard
{
    public class GetDashboardRequest
    {
    }

    public class GetDashboardResponse
    {
        public List<ExecutedCalculationDto> LatestExecutions { get; set; }
    }
}