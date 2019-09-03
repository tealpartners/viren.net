using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Viren.Core.Helpers;
using Viren.Execution.Requests;
using Viren.Execution.Requests.Documentation;

namespace Viren.Execution.Clients
{
    public interface IDocumentationClient
    {
        Task<GetBlocksDetailDocumentationResponse> GetBlocksDetailDocumentation(string project, string model, int version, List<string> blocks, string language, bool? draft = null);
        Task<GetBlocksDocumentationResponse> GetBlocksDocumentation(string project, string model, int version, string language, bool? draft = null);

        Task<GetTypesDocumentationResponse> GetTypesDocumentation(string project, string model, int version, string language, bool? draft = null);
    }
    
    public class DocumentationClient : IDocumentationClient
    {
        private readonly HttpClient _client;

        public DocumentationClient(HttpClient client)
        {
            _client = client;
        }

        public Task<GetBlocksDetailDocumentationResponse> GetBlocksDetailDocumentation(string project, string model, int version, List<string> blocks, string language, bool? draft = null)
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
            
            var languageParam = string.IsNullOrEmpty(language) ? "" : $"Language={language}";
            var blockIds = string.Join("&", blocks.Select((b, i) => $"BlockIds[{i}]={b}"));
            var draftParam = draft.HasValue ? $"Draft={request.Draft}" : "";
            var getPars = $"{blockIds}&{draftParam}&{languageParam}";
            return  _client.Get<GetBlocksDetailDocumentationResponse>($"{RoutePrefix.Api}/documentation/blocks/detail/{UrlBuilder.BuildUrl(request)}?{getPars}");
        }

        
        public Task<GetBlocksDocumentationResponse> GetBlocksDocumentation(string project, string model, int version, string language, bool? draft = null)
        {
            var request = new GetBlocksDocumentationRequest
            {
                Project = project,
                Model = model,
                Version = version,
                Draft = draft,
                
            };
            
            var languageParam = string.IsNullOrEmpty(language) ? "" : $"Language={language}";
            var draftParam = draft.HasValue ? $"Draft={request.Draft}" : "";
            var getPars = $"{draftParam}&{languageParam}";
            return  _client.Get<GetBlocksDocumentationResponse>($"{RoutePrefix.Api}/documentation/blocks/{UrlBuilder.BuildUrl(request)}?{getPars}");
        }
        
        public Task<GetTypesDocumentationResponse> GetTypesDocumentation(string project, string model, int version, string language,  bool? draft = null)
        {
            var request = new GetTypesDocumentationRequest
            {
                Project = project,
                Model = model,
                Version = version,
                Draft = draft,
                Language = language
            };

            var languageParam = string.IsNullOrEmpty(language) ? "" : $"Language={language}";
            var draftParam = draft.HasValue ? $"Draft={request.Draft}" : "";
            var getPars = $"{languageParam}&{draftParam}";
            return  _client.Get<GetTypesDocumentationResponse>($"{RoutePrefix.Api}/documentation/types/{UrlBuilder.BuildUrl(request)}?{getPars}");
        }
    }
}