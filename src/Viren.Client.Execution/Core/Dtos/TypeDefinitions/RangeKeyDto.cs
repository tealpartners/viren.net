using Viren.Client.Execution.Core.Enums;

namespace Viren.Client.Execution.Core.Dtos.TypeDefinitions
{
    public class RangeKeyDto
    {
        public string FromPropertyName { get; set; }

        public string ToPropertyName { get; set; }

        public bool IncludeFrom { get; set; }

        public bool IncludeTo { get; set; }

        public bool IsHistoric { get; set; }

        public KeyType KeyType => KeyType.Range;
    }
}