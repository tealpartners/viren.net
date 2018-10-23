using Viren.Client.Execution.Dtos;

namespace Viren.Client.Execution.Requests.Calculations
{
    public class GetBatchProgressesRequest
    {
    }

    public class GetBatchProgressesResponse
    {
        public BatchCalculationProgressDto[] Batches { get; set; }
    }
}