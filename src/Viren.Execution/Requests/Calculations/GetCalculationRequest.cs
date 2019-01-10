using System;
using System.Collections.Generic;
using Viren.Core.Dtos;

namespace Viren.Execution.Requests.Calculations
{
    public class GetCalculationRequest
    {
        public string Id { get; set; }
    }

    public class GetCalculationResponse
    {
        public GetCalculationResponse()
        {
            ValidationMessages = new List<ValidationMessage>();
        }
        
        public string Id { get; set; }
        public Guid? ConversationId { get; set; }
        public Guid? ImportId { get; set; }

        public string Project { get; set; }
        public string Model { get; set; }
        public int Version { get; set; }
        public int? Revision { get; set; }

        public string EntryPoint { get; set; }

        public DateTime ExecutionBegin { get; set; }
        public DateTime ExecutionEnd { get; set; }

        public IDictionary<string, object> Result { get; set; }
        public IDictionary<string, object> Root { get; set; }
        public IDictionary<string, object> Globals { get; set; }

        public bool IsValid { get; set; }
        public IList<ValidationMessage> ValidationMessages { get; set; }
    }
}