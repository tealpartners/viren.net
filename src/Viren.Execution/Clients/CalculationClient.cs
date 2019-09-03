using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Viren.Core.Enums;
using Viren.Core.Helpers;
using Viren.Execution.Requests;
using Viren.Execution.Requests.Calculations;
using Viren.Execution.Requests.Clients;
using Viren.Execution.Requests.Optimize;

namespace Viren.Execution.Clients
{
    public interface ICalculationClient
    {
        Task<ExecuteCalculationResponse> ExecuteWithLatestVersion(string project, string model, bool draft, string entryPoint,
            IDictionary<string, object> globals = null, IDictionary<string, object> root = null, bool? debug = null, ResultType? resultType = ResultType.ResultProperties, string requestId = null);

        Task<ExecuteCalculationResponse> Execute(string project, string model, int version, string entryPoint,
            IDictionary<string, object> globals = null, IDictionary<string, object> root = null,
            int? revision = null, bool? debug = null, ResultType? resultType = ResultType.ResultProperties, string requestId = null);

        Task<ExecuteCalculationResponse> Execute(ExecuteCalculationRequest request);
        Task<ExecuteCalculationsResponse> Execute(ExecuteCalculationsRequest request);
        Task<OptimizeCalculationResponse> Optimize(OptimizeCalculationRequest request);
        Task<Z3CalculationResponse> Optimize(Z3CalculationRequest request);
        Task<ExecuteCalculationBatchResponse> Batch(ExecuteCalculationBatchRequest request);
    }

    public class CalculationClient : ICalculationClient
    {
        private readonly HttpClient _client;
        private readonly IModelClient _modelClient;

        public CalculationClient(HttpClient client, IModelClient modelClient)
        {
            _client = client;
            _modelClient = modelClient;
        }

        public async Task<ExecuteCalculationResponse> ExecuteWithLatestVersion(string project, string model, bool draft, string entryPoint,
            IDictionary<string, object> globals = null, IDictionary<string, object> root = null, bool? debug = null, ResultType? resultType  = ResultType.ResultProperties, string requestId = null)
        {
            var versionTask = await _modelClient.GetVersion(project, model, draft).ConfigureAwait(false);
            var version = versionTask.Version;
            var revision = versionTask.Revision;
            return await Execute(project, model, version, entryPoint, globals, root, revision, debug, resultType, requestId).ConfigureAwait(false);
        }

        public Task<ExecuteCalculationResponse> Execute(string project, string model, int version, string entryPoint,
            IDictionary<string, object> globals = null, IDictionary<string, object> root = null,
            int? revision = null, bool? debug = null, ResultType? resultType = ResultType.ResultProperties, string requestId = null)
        {
            if (globals == null) globals = new Dictionary<string, object>();

            if (root == null) root = new Dictionary<string, object>();

            if (string.IsNullOrEmpty(requestId)) requestId = Guid.NewGuid().ToString();

            var request = new ExecuteCalculationRequest
            {
                RequestId = requestId,
                Project = project,
                Model = model,
                Version = version,
                EntryPoint = entryPoint,
                Globals = globals,
                Root = root,
                Revision = revision,
                Debug = debug,
                ResultType = resultType
            };
            return Execute(request);
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