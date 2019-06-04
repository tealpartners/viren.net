using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Viren.Core.Dtos;
using Viren.Core.Enums;

namespace Viren.Execution.Requests.Calculations
{
    public class ExecuteCalculationBatchRequest
    {
        public IList<ExecuteCalculationBatchInput> Inputs { get; set; }

        public string ClientSessionId { get; set; }
    }

    public class ExecuteCalculationBatchResponse
    {
        public int BatchId { get; set; }
        public List<ValidationMessage> ValidationMessages { get; set; }

        public ExecuteCalculationBatchResponse()
        {
            ValidationMessages = new List<ValidationMessage>();
        }
    }

    public class ExecuteCalculationBatchInput
    {
        public string Project { get; set; }

        public string Model { get; set; }

        public int Version { get; set; }

        public int? Revision { get; set; }

        public string EntryPoint { get; set; }

        public bool? Debug { get; set; }

        public ResultType? ResultType { get; set; }

        public List<string> CalculationInputHeaders { get; set; }
        public IEnumerable<ExecuteCalculationBatchInputItem> CalculationInputs { get; set; }
    }

    public class ExecuteCalculationBatchInputItem
    {
        public string RequestId { get; set; }
        public List<JValue> Root { get; set; }
        public List<JValue> Globals { get; set; }
    }
}
