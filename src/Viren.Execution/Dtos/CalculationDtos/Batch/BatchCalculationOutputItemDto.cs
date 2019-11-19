using System.Collections.Generic;
using Viren.Core.Dtos;
using Viren.Core.Enums;

namespace Viren.Execution.Dtos.CalculationDtos.Batch
{
    public class BatchCalculationOutputItemDto
    {
        public BatchCalculationOutputItemDto()
        {
            ValidationMessages = new List<ValidationMessage>();
            Result = new Dictionary<string, object>();
        }

        public string RequestId { get; set; }
        public Dictionary<string, object> Result { get; set; }
        public IList<ValidationMessage> ValidationMessages { get; set; }
        public bool IsValid { get; set; }
    }
}