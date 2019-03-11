using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Viren.Core.Dtos;
using Viren.Execution.Dtos.Calculation.Optimize.Z3;

namespace Viren.Execution.Requests.Calculations.Optimize
{
    public class Z3CalculationRequest
    {
        public Z3CalculationRequest()
        {
            Root = new Dictionary<string, object>();
            Globals = new Dictionary<string, object>();
            Inputs = new List<Z3InputInfoDto>();
            Outputs = new List<Z3OutputInfoDto>();
        }

        public string RequestId { get; set; }

        public int BuildRequestId { get; set; }

        public string EntryPoint { get; set; }

        public IDictionary<string, object> Root { get; set; }
        public IDictionary<string, object> Globals { get; set; }

        public List<Z3InputInfoDto> Inputs { get; set; }
        public List<Z3OutputInfoDto> Outputs { get; set; }

        public string ClientSessionId { get; set; }

        public string Project { get; set; }

        public string Model { get; set; }

        public int Version { get; set; }
    }

    public class Z3CalculationResponse
    {
        public Z3CalculationResponse()
        {
            ValidationMessages= new List<ValidationMessage>();
            Results= new List<Z3FullResultDto>();
        }

        public IList<Z3FullResultDto> Results { get; set; }
        public bool IsValid { get; set; }
        public List<ValidationMessage> ValidationMessages { get; set; }
    }


}