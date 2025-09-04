using System.Net.Http;
using System.Threading.Tasks;
using Viren.Core.Helpers;
using Viren.Execution.Requests;
using Viren.Execution.Requests.Calculations;
using Viren.Execution.Requests.Optimize;

namespace Viren.Execution.Clients
{
    public interface ICalculationClient
    {
        Task<ExecuteCalculationResponse> Execute(ExecuteCalculationRequest request);
        Task<ExecuteCalculationsResponse> Execute(ExecuteCalculationsRequest request);
        Task<OptimizeCalculationResponse> Optimize(OptimizeCalculationRequest request);
    }

    public class CalculationClient : ICalculationClient
    {
        private readonly HttpClient _client;

        public CalculationClient(HttpClient client)
        {
            _client = client;
        }
        
        public Task<ExecuteCalculationResponse> Execute(ExecuteCalculationRequest request)
        {
            return _client.Post<ExecuteCalculationRequest, ExecuteCalculationResponse>($"{RoutePrefix.Calculation}?debug={request.Debug}", request);
        }

        public Task<ExecuteCalculationsResponse> Execute(ExecuteCalculationsRequest request)
        {
            return _client.Post<ExecuteCalculationsRequest, ExecuteCalculationsResponse>($"{RoutePrefix.CalculationsV2}", request);
        }

        public Task<OptimizeCalculationResponse> Optimize(OptimizeCalculationRequest request)
        {
            return _client.Post<OptimizeCalculationRequest, OptimizeCalculationResponse>($"{RoutePrefix.Calculation}/optimize", request);
        }
    }
}