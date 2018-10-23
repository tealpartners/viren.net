using Viren.Client.Execution.Core.Enums;

namespace Viren.Client.Execution.Core.Dtos.TypeValues
{
    public class ComplexValueDto : ValueDefinition
    {
        public object[] Values { get; set; }

        public override TypeKind TypeKind => TypeKind.Complex;
    }
}