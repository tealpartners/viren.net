using Viren.Core.Enums;

namespace Viren.Core.Dtos.TypeDefinitions
{
    public class SimpleTypeDto : TypeDefinition
    {
        public SystemType SystemType { get; set; }

        public string Formatting { get; set; }

        public override TypeKind TypeKind => TypeKind.Simple;
    }
}