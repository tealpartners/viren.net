using System.Threading.Tasks;
using Viren.Client.Execution.Requests;
using Viren.Client.Execution.Requests.InteractiveRun;

namespace Viren.Client.Execution.Clients
{
    public class InteractiveRunClient
    {
        private readonly ExecutionClient _client;

        public InteractiveRunClient(ExecutionClient client)
        {
            _client = client;
        }

        public Task<GetInteractiveModelDataResponse> GetVersion(string project, string model, int version, string block, bool? draft = null)
        {
            var request = new GetInteractiveModelDataRequest
            {
                Project = project,
                Model = model,
                Version = version,
                Block = block,
                Draft = draft
            };
            return GetVersion(request);
        }

        public Task<GetInteractiveModelDataResponse> GetVersion(GetInteractiveModelDataRequest request)
        {
            return _client.Get<GetInteractiveModelDataResponse>($"{RoutePrefix.InteractiveModelData}/{_client.BuildUrl(request)}/{request.Block}?Draft={request.Draft}");
        }

     
    }
}