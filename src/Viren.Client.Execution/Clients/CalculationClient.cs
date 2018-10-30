using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Viren.Client.Execution.Clients.Helpers;
using Viren.Client.Execution.Requests;
using Viren.Client.Execution.Requests.Calculations;

namespace Viren.Client.Execution.Clients
{
    public interface ICalculationClient
    {
        Task<ExecuteCalculationResponse> ExecuteWithLatestVersion(string project, string model, bool draft, string entryPoint,
            IDictionary<string, object> globals = null, IDictionary<string, object> root = null, bool? debug = null, bool? full = null, string requestId = null);

        Task<ExecuteCalculationResponse> Execute(string project, string model, int version, string entryPoint,
            IDictionary<string, object> globals = null, IDictionary<string, object> root = null,
            int? revision = null, bool? debug = null, bool? full = null, string requestId = null);

        Task<ExecuteCalculationResponse> Execute(ExecuteCalculationRequest request);
        Task<OptimizeCalculationResponse> Optimize(OptimizeCalculationRequest request);
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
            IDictionary<string, object> globals = null, IDictionary<string, object> root = null, bool? debug = null, bool? full = null, string requestId = null)
        {
            var versionTask = await _modelClient.GetVersion(project, model, draft);
            var version = versionTask.Version;
            var revision = versionTask.Revision;
            return await Execute(project, model, version, entryPoint, globals, root, revision, debug, full, requestId);
        }
        
        public Task<ExecuteCalculationResponse> Execute(string project, string model, int version, string entryPoint,
            IDictionary<string, object> globals = null, IDictionary<string, object> root = null,
            int? revision = null, bool? debug = null, bool? full = null, string requestId = null)
        {
            if (globals == null)
            {
                globals = new Dictionary<string, object>();
            }
            if (root == null)
            {
                root = new Dictionary<string, object>();
            }
            if (string.IsNullOrEmpty(requestId))
            {
                requestId = Guid.NewGuid().ToString();
            }
            
            var request = new ExecuteCalculationRequest()
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
                Full = full
            };
            return Execute(request);
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