using System;
using Viren.Client.Execution.Dtos;

namespace Viren.Client.Execution.Requests.Calculations
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