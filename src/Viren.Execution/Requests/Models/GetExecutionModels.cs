using Viren.Execution.Dtos;

namespace Viren.Execution.Requests.Models
{
    public class GetExecutionModelsRequest
    {
    }

    public class GetExecutionModelsResponse
    {
        public string Code { get; set; }
        public ModelDto[] Models { get; set; }
    }
}