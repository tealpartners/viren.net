namespace Viren.Execution.Requests.Models
{
    public class GetTemplateRequest
    {
        public string Project { get; set; }
        public string Model { get; set; }
        public int Version { get; set; }
        public string EntryPoint { get; set; }
        public int? Revision { get; set; }
    }

    public class GetTemplateResponse
    {
        public string Data { get; set; }
        public string MediaType { get; set; }
        public string FileName { get; set; }
    }
}