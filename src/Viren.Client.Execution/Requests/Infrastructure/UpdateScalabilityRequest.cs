using Viren.Client.Execution.Enums;

namespace Viren.Client.Execution.Requests.Infrastructure
{
    public class UpdateScalabilityRequest
    {
        public int Instances { get; set; }
        public InstanceSize Size { get; set; }
    }

    public class UpdateScalabilityResponse
    {
    }
}