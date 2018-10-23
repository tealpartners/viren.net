using Viren.Client.Execution.Core.Enums;

namespace Viren.Client.Execution.Core.Dtos.TypeValues
{
    public class SimpleValueDto : ValueDefinition
    {
        public object Value { get; set; }

        public SystemType SystemType { get; set; }

        public override TypeKind TypeKind => TypeKind.Simple;
    }
}