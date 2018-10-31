namespace Viren.Execution.Requests.Models
{
    public class PublishModelRequest
    {
        public string Project { get; set; }
        public string Model { get; set; }
        public int Version { get; set; }
        public int? Revision { get; set; }
    }

    public class PublishModelResponse
    {
    }
}