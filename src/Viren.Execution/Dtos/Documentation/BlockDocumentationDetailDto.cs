using System.Collections.Generic;

namespace Viren.Execution.Dtos.Documentation
{
    public class BlockDocumentationDetailDto
    {
        public string BlockId { get; set; }

        public string UsageType { get; set; }
        
        public string BlockType { get; set; }

        public BlockDocumentationOptionalInfoDto OptionalInfo { get; set; }

        public List<BlockDocumentationInputParameterDto> Inputs { get; set; }

        public List<BlockDocumentationOutputParameterDto> Outputs { get; set; }

        public List<BlockDocumentationParameterDto> Results { get; set; }
    }
}