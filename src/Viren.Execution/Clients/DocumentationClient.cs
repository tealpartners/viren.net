using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Viren.Core.Helpers;
using Viren.Execution.Requests;
using Viren.Execution.Requests.Documentation;

namespace Viren.Execution.Clients
{
    public interface IDocumentationClient
    {
        Task<GetBlocksDetailDocumentationResponse> GetBlocksDetailDocumentation(string project, string model, int version, List<string> blocks, string language, bool? draft = null, string draftKey = null);
        Task<GetBlocksDocumentationResponse> GetBlocksDocumentation(string project, string model, int version, string language, bool? draft = null, string draftKey = null);

        Task<GetTypesDocumentationResponse> GetTypesDocumentation(string project, string model, int version, string language, bool? draft = null, string draftKey = null);
    }
    
    public class DocumentationClient : IDocumentationClient
    {
        private readonly HttpClient _client;

        public DocumentationClient(HttpClient client)
        {
            _client = client;
        }

        public Task<GetBlocksDetailDocumentationResponse> GetBlocksDetailDocumentation(string project, string model, int version, List<string> blocks, string language, bool? draft = null, string draftKey = null)
        {
            var request = new GetBlocksDetailDocumentationRequest
            {
                Project = project,
                Model = model,
                Version = version,
                Draft = draft,
                BlockIds = blocks,
                Language = language
                
            };
            
            var queryParams = new List<string>();

            if (!string.IsNullOrEmpty(language))
            {
                queryParams.Add($"Language={language}");
            }

            for (var i = 0; i < blocks.Count; i++)
            {
                queryParams.Add($"BlockIds[{i}]={blocks[i]}");
            }
            if (draftKey != null)
            {
                queryParams.Add($"DraftKey={draftKey}");
            }

            var getPars = string.Join("&", queryParams);

            return  _client.Get<GetBlocksDetailDocumentationResponse>($"{RoutePrefix.Api}/documentation/blocks/detail/{UrlBuilder.BuildUrl(request)}?{getPars}");
        }

        
        public Task<GetBlocksDocumentationResponse> GetBlocksDocumentation(string project, string model, int version, string language, bool? draft = null, string draftKey = null)
        {
            var request = new GetBlocksDocumentationRequest
            {
                Project = project,
                Model = model,
                Version = version,
                Draft = draft,
                
            };

            var queryParams = new List<string>();

            if (!string.IsNullOrEmpty(language))
            {
                queryParams.Add($"Language={language}");
            }

            if (draft.HasValue)
            {
                queryParams.Add($"Draft={draft}");
            }

            if (draftKey != null)
            {
                queryParams.Add($"DraftKey={draftKey}");
            }

            var getPars = string.Join("&", queryParams);
            return  _client.Get<GetBlocksDocumentationResponse>($"{RoutePrefix.Api}/documentation/blocks/{UrlBuilder.BuildUrl(request)}?{getPars}");
        }
        
        public Task<GetTypesDocumentationResponse> GetTypesDocumentation(string project, string model, int version, string language,  bool? draft = null, string draftKey = null)
        {
            var request = new GetTypesDocumentationRequest
            {
                Project = project,
                Model = model,
                Version = version,
                Draft = draft,
                Language = language
            };

            var queryParams = new List<string>();

            if (!string.IsNullOrEmpty(language))
            {
                queryParams.Add($"Language={language}");
            }

            if (draft.HasValue)
            {
                queryParams.Add($"Draft={draft}");
            }

            if (draftKey != null)
            {
                queryParams.Add($"DraftKey={draftKey}");
            }

            var getPars = string.Join("&", queryParams);
            return  _client.Get<GetTypesDocumentationResponse>($"{RoutePrefix.Api}/documentation/types/{UrlBuilder.BuildUrl(request)}?{getPars}");
        }
    }
}