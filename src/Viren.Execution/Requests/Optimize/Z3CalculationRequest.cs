using System.Collections.Generic;
using Calculation.Execution.Contracts.RequestResponses;
using Newtonsoft.Json.Linq;
using Viren.Execution.Dtos.Calculation.Optimize.Z3;

namespace Viren.Execution.Requests.Calculations.Optimize
{
    public class Z3CalculationRequest
    {
        public Z3CalculationRequest()
        {
            Inputs = new List<Z3InputInfoDto>();
            Outputs = new List<Z3OutputInfoDto>();
            Root = new Dictionary<string, object>();
            Globals = new Dictionary<string, object>();
        }

        public string Project { get; set; }
        public string Model { get; set; }
        public int Version { get; set; }
        public bool? isDraft { get; set; }
        public string EntryPoint { get; set; }
        public Dictionary<string, object> Root { get; set; }
        public Dictionary<string, object> Globals { get; set; }
        public List<Z3InputInfoDto> Inputs { get; set; }
        public List<Z3OutputInfoDto> Outputs { get; set; }
        public string ClientSessionId { get; set; }
    }

    public class Z3CalculationResponse: BaseResponse
    {
        public Z3CalculationResponse()
        {
            Results = new List<Z3FullResultDto>();
        }

        public IList<Z3FullResultDto> Results { get; set; }
    }
}