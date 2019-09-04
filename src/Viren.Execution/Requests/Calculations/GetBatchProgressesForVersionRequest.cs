﻿using Viren.Execution.Dtos.CalculationDtos.Batch;

namespace Viren.Execution.Requests.Calculations
{
    public class GetBatchProgressesForVersionRequest
    {
        public string Project { get; set; }
        public string Model { get; set; }
        public int Version { get; set; }
    }

    public class GetBatchProgressesForVersionResponse
    {
        public BatchCalculationProgressDto[] Batches { get; set; }
    }
}