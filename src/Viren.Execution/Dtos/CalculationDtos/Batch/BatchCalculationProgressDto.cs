using System;
using System.Collections.Generic;
using Viren.Core.Dtos;

namespace Viren.Execution.Dtos.CalculationDtos.Batch
{
    public class BatchCalculationProgressDto
    {
        public int? BatchId { get; set; }
        public string CorrelationId { get; set; }

        public UserSummaryDto CreatedBy { get; set; }
        public BatchPhase Phase { get; set; }

        public BatchTimingsDto Timing { get; set; } = new BatchTimingsDto();

        public PhaseProgressDto Import { get; set; }
        public PhaseProgressDto Calculation { get; set; }
        public PhaseProgressDto Reporting { get; set; }

        public List<ValidationMessage> ValidationMessages { get; set; }
    }

    public class UserSummaryDto
    {
        public int Id { get; set; }
    }

    public class BatchTimingsDto
    {
        public DateTime Started { get; set; }
        public DateTime? Completed { get; set; }
        public DateTime Updated { get; set; }
    }

    public class BatchErrorDto
    {
        public string Exception { get; set; }
        public DateTime DateTime { get; set; }
    }

    public class PhaseProgressDto
    {
        public string BatchIdentifier { get; set; }
        public DateTime? Begin { get; set; }
        public DateTime? End { get; set; }
        public double ElapsedMilliseconds { get; set; }
        public double Remainingilliseconds { get; set; }
        public double Percentage { get; set; }
        public int Processed { get; set; }
        public int Total { get; set; }
        public BatchErrorDto Error { get; set; }
        public List<TimeFrame> RequestsPerSecond { get; set; } = new List<TimeFrame>();
    }

    public class TimeFrame
    {
        public int Seconds { get; set; }
        public double? Value { get; set; }
    }

    public enum BatchPhase
    {
        Importing = 0,
        Calculating = 1,
        Reporting = 2,
        Failed = 3,
        Completed = 4
    }
}