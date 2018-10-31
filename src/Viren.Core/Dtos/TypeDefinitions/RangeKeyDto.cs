using Viren.Core.Enums;

namespace Viren.Core.Dtos.TypeDefinitions
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