using Newtonsoft.Json.Linq;
using System;

namespace Viren.Execution.Dtos
{
    public class CalculationResultDto
    {
        public Guid? ConversationId { get; set; }
        public int? BatchId { get; set; }
        public string RequestId { get; set; }
        public string ClientSessionId { get; set; }

        public string Project { get; set; }
        public string Model { get; set; }
        public int Version { get; set; }
        public int? Revision { get; set; }

        public DateTime TimeStamp { get; set; }
        public int ElapsedMilliseconds { get; set; }

        public JObject Result { get; set; }
    }
}