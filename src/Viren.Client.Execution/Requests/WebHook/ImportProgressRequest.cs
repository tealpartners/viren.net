using Viren.Client.Execution.Dtos;

namespace Viren.Client.Execution.Requests.WebHook
{
    public class ImportProgressRequest
    {
        public BatchCalculationProgressDto Progress { get; set; }
    }

    public class ImportProgressResponse
    {
    }
}