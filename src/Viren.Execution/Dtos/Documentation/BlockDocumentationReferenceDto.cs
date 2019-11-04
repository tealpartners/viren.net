using Viren.Core.Enums;

namespace Viren.Execution.Dtos.Documentation
{
    public class BlockDocumentationReferenceDto
    {
        public string Id { get; set; }

        public string Label { get; set; }

        public string UsageType { get; set; }
        public BlockUsageType UsageTypeCode { get; set; }
    }
}