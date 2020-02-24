using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Viren.Core.Helpers;
using Viren.Execution.Requests;
using Viren.Execution.Requests.Models;

namespace Viren.Execution.Clients
{
    public interface IModelClient
    {
        Task<GetLatestVersionResponse> GetVersion(string project, string model, bool draft);
        Task<GetLatestVersionResponse> GetVersion(GetLatestVersionRequest request);
        Task<GetLookupTableResponse> GetTable(string project, string model, int version, string tableName, int? revision = null);
        Task<GetLookupTableResponse> GetTable(GetLookupTableRequest request);
        Task<GetLookupTablesResponse> GetTables(string project, string model, int version, string[] tableNames, int? revision = null);
        Task<GetLookupTablesResponse> GetTables(GetLookupTablesRequest request);
    }

    public class ModelClient : IModelClient
    {
        private readonly HttpClient _client;

        public ModelClient(HttpClient client)
        {
            _client = client;
        }

        public Task<GetLatestVersionResponse> GetVersion(string project, string model, bool draft)
        {
            var request = new GetLatestVersionRequest
            {
                Project = project,
                Model = model,
                Draft = draft
            };
            return GetVersion(request);
        }

        public Task<GetLatestVersionResponse> GetVersion(GetLatestVersionRequest request)
        {
            return _client.Get<GetLatestVersionResponse>($"{RoutePrefix.Project}/{UrlBuilder.BuildUrl(request)}/latest-version?Draft={request.Draft}");
        }

        public Task<GetLookupTableResponse> GetTable(string project, string model, int version, string tableName, int? revision = null)
        {
            var request = new GetLookupTableRequest
            {
                Project = project,
                Model = model,
                Version = version,
                Id = tableName,
                Revision = revision
            };
            return GetTable(request);
        }

        public Task<GetLookupTableResponse> GetTable(GetLookupTableRequest request)
        {
            return _client.Get<GetLookupTableResponse>($"{RoutePrefix.Project}/{UrlBuilder.BuildUrl(request)}/globals/lookup-tables/{request.Id}");
        }

        public Task<GetLookupTablesResponse> GetTables(string project, string model, int version, string[] tableNames, int? revision = null)
        {
            var request = new GetLookupTablesRequest
            {
                Project = project,
                Model = model,
                Version = version,
                GlobalIds = tableNames,
                Revision = revision
            };
            return GetTables(request);
        }

        public Task<GetLookupTablesResponse> GetTables(GetLookupTablesRequest request)
        {
            var url = $"{RoutePrefix.Project}/{UrlBuilder.BuildUrl(request)}/globals/tables?";
            url = request.GlobalIds.Aggregate(url, (current, globalId) => current + "GlobalIds=" + globalId + "&").TrimEnd('&');
            return _client.Get<GetLookupTablesResponse>(url);
        }
    }
}