using System;
using System.Collections.Generic;
using Viren.Core.Dtos;

namespace Viren.Execution.Dtos.CalculationDtos
{
    public class ExecutedCalculationDto
    {
        public ExecutedCalculationDto()
        {
            Result = new Dictionary<string, object>();            
            Root = new Dictionary<string, object>();            
            Globals = new Dictionary<string, object>();            
        }
        
        public string Id { get; set; }
        public Guid? ConversationId { get; set; }
        public Guid? ImportId { get; set; }
        public string ClientSessionId { get; set; }
        public string CalculationType { get; set; }

        public string Project { get; set; }
        public string Model { get; set; }
        public int Version { get; set; }
        public int? Revision { get; set; }

        public string EntryPoint { get; set; }

        public DateTime ExecutionBegin { get; set; }
        public DateTime ExecutionEnd { get; set; }

        public Dictionary<string, object> Result { get; set; }
        public Dictionary<string, object>  Root { get; set; }
        public Dictionary<string, object>  Globals { get; set; }

        public bool IsValid { get; set; }
        public IList<ValidationMessage> ValidationMessages { get; set; }

        public string ProfileId { get; set; }
    }
}