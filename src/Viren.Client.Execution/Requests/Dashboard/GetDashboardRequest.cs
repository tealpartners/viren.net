using System.Collections.Generic;
using Viren.Client.Execution.Dtos;

namespace Viren.Client.Execution.Requests.Dashboard
{
    public class GetDashboardRequest
    {
    }

    public class GetDashboardResponse
    {
        public List<ExecutedCalculationDto> LatestExecutions { get; set; }
    }
}