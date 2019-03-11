using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Viren.Core.Dtos;

namespace Viren.Execution.Dtos.Calculation
{
    public class ExecutedCalculationDto
    {
        public string Id { get; set; }
        public Guid? ConversationId { get; set; }
        public Guid? ImportId { get; set; }
        public string ClientSessionId { get; set;  }
        public string CalculationType { get; set;  }

        public string Project { get; set; }
        public string Model { get; set; }
        public int Version { get; set; }
        public int? Revision { get; set; }

        public string EntryPoint { get; set; }

        public DateTime ExecutionBegin { get; set; }
        public DateTime ExecutionEnd { get; set; }

        public JObject Result { get; set; }
        public JObject Root { get; set; }
        public JObject Globals { get; set; }

        public bool IsValid { get; set; }
        public IList<ValidationMessage> ValidationMessages { get; set; }

        public string ProfileId { get; set; }
    }
}