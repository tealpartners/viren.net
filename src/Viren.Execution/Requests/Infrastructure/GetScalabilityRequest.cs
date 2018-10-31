using Viren.Execution.Enums;

namespace Viren.Execution.Requests.Infrastructure
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