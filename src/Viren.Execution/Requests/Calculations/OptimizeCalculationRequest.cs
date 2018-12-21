using System;
using System.Collections.Generic;
using Viren.Core.Dtos;
using Viren.Execution.Dtos.OptimizeCalculation;

namespace Viren.Execution.Requests.Calculations
{
    public class OptimizeCalculationRequest
    {
        public string RequestId = Guid.NewGuid().ToString();

        public OptimizeCalculationRequest()
        {
            OptimizeInputs = new List<OptimizeInputInfoDto>();
            Root = new Dictionary<string, object>();
            Globals = new Dictionary<string, object>();
        }

        public string Project { get; set; }
        public string Model { get; set; }
        public int Version { get; set; }
        public int? Revision { get; set; }

        public string EntryPoint { get; set; }

        public IDictionary<string, object> Root { get; set; }
        public IDictionary<string, object> Globals { get; set; }

        public IList<OptimizeInputInfoDto> OptimizeInputs { get; set; }
        public OptimizeOutputInfoDto OptimizeOutput { get; set; }

        public string ClientSessionId { get; set; }
    }

    public class OptimizeCalculationResponse
    {
        public Dictionary<string, object> Result { get; set; }
        public Dictionary<string, object> Input { get; set; }
        public string AbortReason { get; set; }
        public List<OptimizeAttempt> Attempts { get; set; }
        
        public bool IsValid { get; set; }
        public List<ValidationMessage> ValidationMessages { get; set; }
    }
}