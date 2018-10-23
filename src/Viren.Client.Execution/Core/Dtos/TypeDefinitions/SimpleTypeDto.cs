using Viren.Client.Execution.Core.Enums;

namespace Viren.Client.Execution.Core.Dtos.TypeDefinitions
{
    public class SimpleTypeDto : TypeDefinition
    {
        public SystemType SystemType { get; set; }

        public string Formatting { get; set; }

        public override TypeKind TypeKind => TypeKind.Simple;
    }
}