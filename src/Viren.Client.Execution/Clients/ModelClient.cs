using System.Linq;
using System.Threading.Tasks;
using Viren.Client.Execution.Requests;
using Viren.Client.Execution.Requests.Models;

namespace Viren.Client.Execution.Clients
{
    public class ModelClient
    {
        private readonly ExecutionClient _client;

        public ModelClient(ExecutionClient client)
        {
            _client = client;
        }

        public Task<GetLatestVersionResponse> GetVersion(GetLatestVersionRequest request)
        {
            return _client.Get<GetLatestVersionResponse>($"{RoutePrefix.Project}/{_client.BuildUrl(request)}/latest-version?draft={request.Draft}");
        }

        public Task<GetLookupTableResponse> GetTable(GetLookupTableRequest request)
        {
            return _client.Get<GetLookupTableResponse>($"{RoutePrefix.Project}/{_client.BuildUrl(request)}/globals/table");
        }

        public Task<GetLookupTablesResponse> GetTables(GetLookupTablesRequest request)
        {
            var url = $"{RoutePrefix.Project}/{_client.BuildUrl(request)}/globals/tables?";
            url = request.GlobalIds.Aggregate(url, (current, globalId) => current + "GlobalIds=" + globalId + "&").TrimEnd('&');
            return _client.Get<GetLookupTablesResponse>(url);
        }
    }
}