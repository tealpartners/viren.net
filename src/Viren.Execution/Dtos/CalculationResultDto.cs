using System;
using System.Collections.Generic;

namespace Viren.Execution.Dtos
{
    public class CalculationResultDto
    {
        public CalculationResultDto()
        {
            RequestId = Guid.NewGuid().ToString();
        }

        public string RequestId { get; set; }
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