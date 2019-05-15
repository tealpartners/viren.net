using System.Collections.Generic;
using Viren.Core.Dtos;
using Viren.Execution.Dtos;

namespace Viren.Execution.Requests.Calculations
{
    public class ExecuteCalculationsRequest
    {
        public ExecuteCalculationsRequest()
        {
            BatchCalculationInputItemDto = new List<BatchCalculationInputItemDto>();
        }

        public IList<BatchCalculationInputItemDto> BatchCalculationInputItemDto { get; set; }

        public string ClientSessionId { get; set; }
    }

    public class ExecuteCalculationsResponse
    {
        public ExecuteCalculationsResponse()
        {
            ValidationMessages = new List<ValidationMessage>();
            BatchCalculationOutputItemDtos = new List<BatchCalculationOutputItemDto>();
        }

        public List<ValidationMessage> ValidationMessages { get; set; }

        public long ElapsedMilliseconds { get; set; }

        public List<BatchCalculationOutputItemDto> BatchCalculationOutputItemDtos { get; set; }
    }
}