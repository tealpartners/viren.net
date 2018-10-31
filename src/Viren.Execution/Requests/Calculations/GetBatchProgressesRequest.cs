using Viren.Execution.Dtos;

namespace Viren.Execution.Requests.Calculations
{
    public class GetBatchProgressesRequest
    {
    }

    public class GetBatchProgressesResponse
    {
        public BatchCalculationProgressDto[] Batches { get; set; }
    }
}