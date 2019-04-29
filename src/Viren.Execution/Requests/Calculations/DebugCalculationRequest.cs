using System.Collections.Generic;
using Viren.Core.Dtos;
using Viren.Execution.Dtos.AssemblyBuilder;

namespace Viren.Execution.Requests.Calculations
{
    public class DebugCalculationRequest
    {
        public string Id { get; set; }

        public string ClientSessionId { get; set; }
    }


    public class DebugCalculationResponse
    {
        public DebugCalculationResponse()
        {
            ValidationMessages = new List<ValidationMessage>();
        }

        public dynamic CalculationResult { get; set; }

        public ModelDebugParsingDto ModelParsing { get; set; }

        public Dictionary<string, Dictionary<string, object>> DebugInfo { get; set; }

        public bool IsValid { get; set; }

        public IList<ValidationMessage> ValidationMessages { get; set; }

        public string Id { get; set; }
    }
}