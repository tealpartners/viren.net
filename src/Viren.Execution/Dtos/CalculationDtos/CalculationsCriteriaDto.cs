using System;

namespace Viren.Execution.Dtos.CalculationDtos
{
    public class CalculationsCriteriaDto
    {
        public string CalculationId { get; set; }
        public string ProfileId { get; set; }
        public Guid? ImportId { get; set; }
        public Guid? ConversationId { get; set; }
        public string CalculationType { get; set; }
        public string ClientSessionId { get; set; }

        public DateTime? From { get; set; }
        public DateTime? To { get; set; }

        public string Project { get; set; }
        public string Model { get; set; }
        public int? Version { get; set; }
        public int? Revision { get; set; }

        public int Page { get; set; }
        public int? PageSize { get; set; }

        public bool? IsValid { get; set; }
        public bool? HasWarning { get; set; }
        public bool? HasError { get; set; }
        public bool SortDescending { get; set; }
    }
}