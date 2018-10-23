using Viren.Client.Execution.Dtos;

namespace Viren.Client.Execution.Requests.WebHook
{
    public class CalculationCompleteRequest
    {
        public CalculationResultDto[] Results { get; set; }
    }

    public class CalculationCompleteResponse
    {
    }
}