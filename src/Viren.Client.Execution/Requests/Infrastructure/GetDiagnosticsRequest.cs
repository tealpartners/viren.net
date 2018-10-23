using System.Collections.Generic;

namespace Viren.Client.Execution.Requests.Infrastructure
{
    public class GetDiagnosticsRequest
    {
        public bool Compact { get; set; }
        public bool WakeUp { get; set; }
    }

    public class GetDiagnosticsResponse
    {
        public IDictionary<string, object> Status { get; set; }
    }
}