using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Viren.Core.Dtos;

namespace Viren.Execution.Dtos
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