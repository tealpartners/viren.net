using Viren.Execution.Dtos;

namespace Viren.Execution.Requests.WebHook
{
    public class ImportProgressRequest
    {
        public BatchCalculationProgressDto Progress { get; set; }
    }

    public class ImportProgressResponse
    {
    }
}