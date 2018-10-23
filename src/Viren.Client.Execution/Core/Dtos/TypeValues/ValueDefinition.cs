using Viren.Client.Execution.Core.Enums;

namespace Viren.Client.Execution.Core.Dtos.TypeValues
{
    public abstract class ValueDefinition
    {
        public string TypeName { get; set; }

        public abstract TypeKind TypeKind { get; }
    }
}