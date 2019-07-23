using System.Collections.Generic;

namespace Viren.Execution.Dtos.Documentation
{
    public class BlockDocumentationDetailDto
    {
        public string BlockId { get; set; }

        public string UsageType { get; set; }

        public BlockDocumentationOptionalInfoDto OptionalInfo { get; set; }

        public List<BlockDocumentationParameterDto> Inputs { get; set; }

        public List<BlockDocumentationParameterDto> Outputs { get; set; }

        public List<BlockDocumentationParameterDto> Results { get; set; }
    }
}