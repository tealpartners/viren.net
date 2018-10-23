using System.Collections.Generic;
using Viren.Client.Execution.Core.Dtos;
using Viren.Client.Execution.Dtos.AssemblyBuilder;

namespace Viren.Client.Execution.Requests.Calculations
{
    public class DebugCalculationRequest
    {
        public string Id { get; set; }
    }


    public class DebugCalculationResponse
    {
        public dynamic CalculationResult { get; set; }

        public ModelDebugParsingDto ModelParsing { get; set; }

        public Dictionary<string, Dictionary<string, object>> DebugInfo { get; set; }

        public bool IsValid { get; set; }

        public IList<ValidationMessage> ValidationMessages { get; set; }

        public string Id { get; set; }
    }
}