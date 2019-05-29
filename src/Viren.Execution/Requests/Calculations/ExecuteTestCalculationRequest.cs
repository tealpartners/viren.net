using System;
using System.Collections.Generic;
using Viren.Core.Dtos;
using Viren.Core.Enums;
using Viren.Execution.Dtos;

namespace Viren.Execution.Requests.Calculations
{
    public class ExecuteTestCalculationRequest
    {
        public ExecuteTestCalculationRequest()
        {
            RequestId = Guid.NewGuid().ToString();
        }

        public string RequestId { get; set; }
        public string Project { get; set; }
        public string Model { get; set; }
        public int Version { get; set; }
        public int? Revision { get; set; }

        public string EntryPoint { get; set; }

        public IDictionary<string, object> Root { get; set; }
        public IDictionary<string, object> Globals { get; set; }
        public bool? Debug { get; set; }
        public ResultType? ResultType { get; set; }

        public string ClientSessionId { get; set; }
    }

    public class ExecuteTestCalculationResponse
    {
        public ExecuteTestCalculationResponse()
        {
            ValidationMessages = new List<ValidationMessage>();
        }

        public ParameterNameValueTypeDto[] Result { get; set; }
        public IDictionary<string, object> FullResult { get; set; }
        public IList<ValidationMessage> ValidationMessages { get; set; }
        public bool IsValid { get; set; }
    }
}