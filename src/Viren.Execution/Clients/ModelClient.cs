using System.Collections.Generic;
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
        Task<GetLatestVersionResponse> GetVersion(string project, string model, bool draft, string draftKey = null);
        Task<GetLatestVersionResponse> GetVersion(GetLatestVersionRequest request);
        Task<GetLookupTableResponse> GetTable(string project, string model, int version, string tableName, int? revision = null, string draftKey = null);
        Task<GetLookupTableResponse> GetTable(GetLookupTableRequest request);
        Task<GetLookupTablesResponse> GetTables(string project, string model, int version, string[] tableNames, int? revision = null, string draftKey = null);
        Task<GetLookupTablesResponse> GetTables(GetLookupTablesRequest request);
    }

    public class ModelClient : IModelClient
    {
        private readonly HttpClient _client;

        public ModelClient(HttpClient client)
        {
            _client = client;
        }

        public Task<GetLatestVersionResponse> GetVersion(string project, string model, bool draft, string draftKey = null)
        {
            var request = new GetLatestVersionRequest
            {
                Project = project,
                Model = model,
                Draft = draft,
                DraftKey = draftKey
            };
            return GetVersion(request);
        }

        public Task<GetLatestVersionResponse> GetVersion(GetLatestVersionRequest request)
        {
            var queryParams = new List<string>();
            queryParams.Add($"Draft={request.Draft}");
            if (request.DraftKey != null)
            {
                queryParams.Add($"DraftKey={request.DraftKey}");
            }

            var getParams = string.Join("&", queryParams);
            return _client.Get<GetLatestVersionResponse>($"{RoutePrefix.Project}/{UrlBuilder.BuildUrl(request)}/latest-version?{getParams}");
        }

        public Task<GetLookupTableResponse> GetTable(string project, string model, int version, string tableName, int? revision = null, string draftKey = null)
        {
            var request = new GetLookupTableRequest
            {
                Project = project,
                Model = model,
                Version = version,
                Id = tableName,
                Revision = revision,
                DraftKey = draftKey
            };
            return GetTable(request);
        }

        public Task<GetLookupTableResponse> GetTable(GetLookupTableRequest request)
        {
            var queryParams = new List<string>();

            if (request.DraftKey != null)
            {
                queryParams.Add($"DraftKey={request.DraftKey}");
            }

            var getParams = string.Join("&", queryParams);
            return _client.Get<GetLookupTableResponse>($"{RoutePrefix.Project}/{UrlBuilder.BuildUrl(request)}/globals/lookup-tables/{request.Id}?{getParams}");
        }

        public Task<GetLookupTablesResponse> GetTables(string project, string model, int version, string[] tableNames, int? revision = null, string draftKey = null)
        {
            var request = new GetLookupTablesRequest
            {
                Project = project,
                Model = model,
                Version = version,
                GlobalIds = tableNames,
                Revision = revision,
                DraftKey = draftKey
            };
            return GetTables(request);
        }

        public Task<GetLookupTablesResponse> GetTables(GetLookupTablesRequest request)
        {
            var queryParams = new List<string>();

            //TODO: Zeker is geod testne want was vroeger nogal raar geschreven, werkte dat vroeger ??
            for (var i = 0; i < request.GlobalIds.Length; i++)
            {
                queryParams.Add($"GlobalIds[{i}]={request.GlobalIds[i]}");
            }


            if (request.DraftKey != null)
            {
                queryParams.Add($"DraftKey={request.DraftKey}");
            }

            var getParams = string.Join("&", queryParams);

            var url = $"{RoutePrefix.Project}/{UrlBuilder.BuildUrl(request)}/globals/tables?{getParams}";
            return _client.Get<GetLookupTablesResponse>(url);
        }
    }
}