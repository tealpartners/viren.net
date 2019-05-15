using System.Collections.Generic;
using Viren.Core.Dtos;
using Viren.Execution.Dtos;

namespace Viren.Execution.Requests.Calculations
{
    public class ExecuteCalculationsRequest
    {
        public ExecuteCalculationsRequest()
        {
            BatchCalculationInputItems = new List<BatchCalculationInputItemDto>();
        }

        public IList<BatchCalculationInputItemDto> BatchCalculationInputItems { get; set; }

        public string ClientSessionId { get; set; }
    }

    public class ExecuteCalculationsResponse
    {
        public ExecuteCalculationsResponse()
        {
            ValidationMessages = new List<ValidationMessage>();
            BatchCalculationOutputItems = new List<BatchCalculationOutputItemDto>();
        }

        public List<ValidationMessage> ValidationMessages { get; set; }

        public long ElapsedMilliseconds { get; set; }

        public List<BatchCalculationOutputItemDto> BatchCalculationOutputItems { get; set; }
    }
}