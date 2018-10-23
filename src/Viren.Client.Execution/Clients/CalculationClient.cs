using System.Threading.Tasks;
using Viren.Client.Execution.Requests;
using Viren.Client.Execution.Requests.Calculations;

namespace Viren.Client.Execution.Clients
{
    public class CalculationClient
    {
        private readonly ExecutionClient _client;

        public CalculationClient(ExecutionClient client)
        {
            _client = client;
        }

        public Task<ExecuteCalculationResponse> Execute(ExecuteCalculationRequest request)
        {
            return _client.Post<ExecuteCalculationRequest, ExecuteCalculationResponse>($"{RoutePrefix.Calculation}?debug={request.Debug}&full={request.Full}", request);
        }

        public Task<OptimizeCalculationResponse> Optimize(OptimizeCalculationRequest request)
        {
            return _client.Post<OptimizeCalculationRequest, OptimizeCalculationResponse>($"{RoutePrefix.Calculation}/optimize", request);
        }
    }
}