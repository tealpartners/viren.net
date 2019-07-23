using System.Collections.Generic;
using Viren.Core.Dtos;
using Viren.Execution.Dtos.Documentation;

namespace Viren.Execution.Requests.Documentation
{
    public class GetBlocksDocumentationRequest :IProjectModelVersion
    {
        public string Project { get; set; }
        public string Model { get; set; }
        public int Version { get; set; }
        public bool? Draft { get; set; }
    }

    public class GetBlocksDocumentationResponse: BaseResponse
    {
        public GetBlocksDocumentationResponse()
        {
            Blocks=new List<BlockDocumentationReferenceDto>();
        }

        public List<BlockDocumentationReferenceDto> Blocks { get; set; }
    }
}