using System.Collections.Generic;
using Viren.Execution.Dtos.CalculationDtos;

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