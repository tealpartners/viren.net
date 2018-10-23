using System;
using System.Collections.Generic;
using Viren.Client.Execution.Core.Dtos;
using Viren.Client.Execution.Dtos;

namespace Viren.Client.Execution.Requests.Calculations
{
    public class ExecuteTestCalculationRequest
    {
        public string RequestId = Guid.NewGuid().ToString();
        public string Project { get; set; }
        public string Model { get; set; }
        public int Version { get; set; }
        public int? Revision { get; set; }

        public string EntryPoint { get; set; }

        public IDictionary<string, object> Root { get; set; }
        public IDictionary<string, object> Globals { get; set; }
        public bool? Debug { get; set; }
        public bool? Full { get; set; }
    }

    public class ExecuteTestCalculationResponse
    {
        public ParameterNameValueTypeDto[] Result { get; set; }
        public IDictionary<string, object> FullResult { get; set; }
        public IList<ValidationMessage> ValidationMessages { get; set; }
        public bool IsValid { get; set; }
    }
}