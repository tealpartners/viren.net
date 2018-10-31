using System;
using System.Collections.Generic;
using Viren.Core.Enums;

namespace Viren.Execution.Dtos
{
    public class BatchCalculationProgressDto
    {
        public Guid ImportId { get; set; }
        public string Comment { get; set; }

        public UserSummaryDto CreatedBy { get; set; }
        public BatchPhase Phase { get; set; }

        public BatchModelDto Model { get; set; } = new BatchModelDto();
        public BatchTimingsDto Timing { get; set; } = new BatchTimingsDto();

        public PhaseProgressDto Import { get; set; }
        public PhaseProgressDto Calculation { get; set; }
        public PhaseProgressDto Reporting { get; set; }

        public BatchErrorDto Errors { get; set; }
    }

    public class UserSummaryDto
    {
        public string Name { get; set; }
        public string Id { get; set; }
    }

    public class BatchTimingsDto
    {
        public DateTime Started { get; set; }
        public DateTime? Completed { get; set; }
        public DateTime Updated { get; set; }
    }

    public class BatchModelDto
    {
        public string Project { get; set; }
        public string Model { get; set; }
        public int Version { get; set; }
        public int? Revision { get; set; }
        public string EntryPoint { get; set; }
    }

    public class BatchErrorDto
    {
        public string Exception { get; set; }
        public string Source { get; set; }
        public DateTime DateTime { get; set; }
    }

    public class PhaseProgressDto
    {
        public double ElapsedMilliseconds { get; set; }
        public double Remainingilliseconds { get; set; }
        public double Percentage { get; set; }
        public int Processed { get; set; }
        public int Total { get; set; }
        public List<TimeFrame> RequestsPerSecond { get; set; } = new List<TimeFrame>();
    }

    public class TimeFrame
    {
        public int Seconds { get; set; }
        public double? Value { get; set; }
    }
}