using System;
using System.Collections.Generic;
using Viren.Client.Execution.Dtos.OptimizeCalculation;

namespace Viren.Client.Execution.Requests.Calculations
{
    public class OptimizeCalculationRequest
    {
        public string RequestId = Guid.NewGuid().ToString();

        public OptimizeCalculationRequest()
        {
            OptimizeInputs = new List<OptimizeInputInfoDto>();
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
    }

    public class OptimizeCalculationResponse
    {
        public Dictionary<string, object> Result { get; set; }
        public Dictionary<string, object> Input { get; set; }
        public string AbortReason { get; set; }
        public List<OptimizeAttempt> Attempts { get; set; }
    }
}