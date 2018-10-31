using System.Collections.Generic;
using Viren.Core.Dtos;
using Viren.Execution.Dtos;

namespace Viren.Execution.Requests.Calculations
{
    public class ExecuteCalculationsRequest
    {
        public ExecuteCalculationsRequest()
        {
            CalculationInputs = new List<CalculationInputDto>();
        }

        public string Project { get; set; }
        public string Model { get; set; }
        public int Version { get; set; }
        public int? Revision { get; set; }

        public string EntryPoint { get; set; }

        public bool? Debug { get; set; }
        public bool? Full { get; set; }

        public IList<CalculationInputDto> CalculationInputs { get; set; }
    }

    public class ExecuteCalculationsResponse
    {
        public ExecuteCalculationsResponse()
        {
            Result = new Dictionary<string, object>();
            ValidationMessages = new Dictionary<string, IList<ValidationMessage>>();
            IsValid = new Dictionary<string, bool>();
        }

        public IDictionary<string, object> Result { get; set; }
        public long ElapsedMilliseconds { get; set; }
        public IDictionary<string, IList<ValidationMessage>> ValidationMessages { get; set; }
        public IDictionary<string, bool> IsValid { get; set; }
    }
}