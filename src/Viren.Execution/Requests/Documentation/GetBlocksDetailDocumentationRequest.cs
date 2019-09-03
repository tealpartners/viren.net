using System.Collections.Generic;
using Viren.Core.Dtos;
using Viren.Execution.Dtos.Documentation;

namespace Viren.Execution.Requests.Documentation
{
    public class GetBlocksDetailDocumentationRequest :IProjectModelVersion
    {
        public string Project { get; set; }
        public string Model { get; set; }
        public int Version { get; set; }
        public bool? Draft { get; set; }

        public List<string> BlockIds { get; set; }

        public string Language { get; set; }
    }

    public class GetBlocksDetailDocumentationResponse : BaseResponse
    {
        public List<BlockDocumentationDetailDto> Blocks { get; set; }
    }
}