using System;
using System.Collections.Generic;
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

        public Task<ExecuteCalculationResponse> ExecuteWithLatestVersion(string project, string model, bool draft, string entryPoint,
            IDictionary<string, object> globals = null, IDictionary<string, object> root = null, bool? debug = null, bool? full = null, string requestId = null)
        {
            var versionTask = _client.Model.GetVersion(project, model, draft);
            versionTask.Wait();
            var version = versionTask.Result.Version;
            var revision = versionTask.Result.Revision;
            return Execute(project, model, version, entryPoint, globals, root, revision, debug, full, requestId);
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