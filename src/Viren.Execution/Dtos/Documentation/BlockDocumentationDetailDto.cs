using System.Collections.Generic;
using Viren.Core.Enums;

namespace Viren.Execution.Dtos.Documentation
{
    public class BlockDocumentationDetailDto
    {
        public string BlockId { get; set; }

        public string Label { get; set; }

        public string UsageType { get; set; }
        public BlockUsageType UsageTypeCode { get; set; }

        public string BlockType { get; set; }
        public BlockType BlockTypeCode { get; set; }

        public BlockDocumentationOptionalInfoDto OptionalInfo { get; set; }

        public List<BlockDocumentationInputParameterDto> Inputs { get; set; }

        public List<BlockDocumentationOutputParameterDto> Outputs { get; set; }

        public List<BlockDocumentationParameterDto> Results { get; set; }
    }
}