using Viren.Execution.Dtos;

namespace Viren.Execution.Requests.WebHook
{
    public class CalculationCompleteRequest
    {
        public int BatchId { get; set; }
        public CalculationResultDto[] Results { get; set; }
    }

    public class CalculationCompleteResponse
    {
    }
}