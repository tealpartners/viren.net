using System;
using Viren.Execution.Dtos;

namespace Viren.Execution.Requests.Calculations
{
    public class GetBatchProgressRequest
    {
        public Guid ImportId { get; set; }
    }

    public class GetBatchProgressResponse
    {
        public BatchCalculationProgressDto Progress { get; set; }
    }
}