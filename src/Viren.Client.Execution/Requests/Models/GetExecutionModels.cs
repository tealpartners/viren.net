using Viren.Client.Execution.Dtos;

namespace Viren.Client.Execution.Requests.Models
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