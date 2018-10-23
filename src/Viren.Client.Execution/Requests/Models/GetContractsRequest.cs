namespace Viren.Client.Execution.Requests.Models
{
    public class GetContractsRequest
    {
        public string Project { get; set; }
        public string Model { get; set; }
        public int Version { get; set; }
        public string EntryPoint { get; set; }
    }

    public class GetContractsResponse
    {
        public string Code { get; set; }
    }
}