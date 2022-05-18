using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Viren.Core.Helpers;
using Viren.Execution.Helpers;
using Viren.Execution.Requests;
using Viren.Execution.Requests.Calculations;
using Viren.Execution.Requests.Optimize;

[assembly:InternalsVisibleTo("Viren.Tests")]
namespace Viren.Execution.Clients
{
    public interface ICalculationClient
    {
        Task<ExecuteCalculationResponse> Execute(ExecuteCalculationRequest request);
        Task<ExecuteCalculationsResponse> Execute(ExecuteCalculationsRequest request, bool batch = false);
        Task<OptimizeCalculationResponse> Optimize(OptimizeCalculationRequest request);
        Task<Z3CalculationResponse> Optimize(Z3CalculationRequest request);
        Task<ExecuteCalculationBatchResponse> Batch(ExecuteCalculationBatchRequest request);
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

        public async Task<ExecuteCalculationsResponse> Execute(ExecuteCalculationsRequest request, bool batch = false)
        {
            return batch ? await Hestia.Protect(request, this) : await ExecuteInternal(request);
        }

        internal virtual Task<ExecuteCalculationsResponse> ExecuteInternal(ExecuteCalculationsRequest request)
        {
            return _client.Post<ExecuteCalculationsRequest, ExecuteCalculationsResponse>($"{RoutePrefix.CalculationsV2}", request);
        }

        public Task<OptimizeCalculationResponse> Optimize(OptimizeCalculationRequest request)
        {
            return _client.Post<OptimizeCalculationRequest, OptimizeCalculationResponse>($"{RoutePrefix.Calculation}/optimize", request);
        }

        public Task<Z3CalculationResponse> Optimize(Z3CalculationRequest request)
        {
            return _client.Post<Z3CalculationRequest, Z3CalculationResponse>($"{RoutePrefix.Calculation}/optimize/z3", request);
        }

        public Task<ExecuteCalculationBatchResponse> Batch(ExecuteCalculationBatchRequest request)
        {
            return _client.Post<ExecuteCalculationBatchRequest, ExecuteCalculationBatchResponse>($"{RoutePrefix.Calculation}/batch", request);
        }
    }
}