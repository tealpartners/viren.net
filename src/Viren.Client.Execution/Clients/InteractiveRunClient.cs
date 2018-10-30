using System.Net.Http;
using System.Threading.Tasks;
using Viren.Client.Execution.Clients.Helpers;
using Viren.Client.Execution.Requests;
using Viren.Client.Execution.Requests.InteractiveRun;

namespace Viren.Client.Execution.Clients
{
    public interface IInteractiveRunClient
    {
        Task<GetInteractiveModelDataResponse> GetVersion(string project, string model, int version, string block, bool? draft = null);
        Task<GetInteractiveModelDataResponse> GetVersion(GetInteractiveModelDataRequest request);
    }

    public class InteractiveRunClient : IInteractiveRunClient
    {
        private readonly HttpClient _client;

        public InteractiveRunClient(HttpClient client)
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
            return _client.Get<GetInteractiveModelDataResponse>($"{RoutePrefix.InteractiveModelData}/{UrlBuilder.BuildUrl(request)}/{request.Block}?Draft={request.Draft}");
        }
    }
}