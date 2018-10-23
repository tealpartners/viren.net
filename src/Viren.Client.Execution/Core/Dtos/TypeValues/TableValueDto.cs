using Viren.Client.Execution.Core.Enums;

namespace Viren.Client.Execution.Core.Dtos.TypeValues
{
    public class TableValueDto : ValueDefinition
    {
        public object[][] Rows { get; set; }

        public override TypeKind TypeKind => TypeKind.Table;
    }
}