using System;
using System.Collections.Generic;

namespace Viren.Client.Execution.Dtos
{
    public class CalculationResultDto
    {
        public string RequestId = Guid.NewGuid().ToString();
        public Guid? ConversationId { get; set; }
        public Guid? ImportId { get; set; }

        public string Project { get; set; }
        public string Model { get; set; }
        public int Version { get; set; }
        public int? Revision { get; set; }

        public DateTime TimeStamp { get; set; }
        public int ElapsedMilliseconds { get; set; }

        public IDictionary<string, object> Result { get; set; }
    }
}