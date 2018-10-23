using Viren.Client.Execution.Enums;

namespace Viren.Client.Execution.Requests.Infrastructure
{
    public class GetScalabilityRequest
    {
    }

    public class GetScalabilityResponse
    {
        public int Instances { get; set; }
        public InstanceSize Size { get; set; }
    }
}