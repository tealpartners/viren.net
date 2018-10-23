using Viren.Client.Execution.Core.Dtos.General;
using Viren.Client.Execution.Core.Enums;

namespace Viren.Client.Execution.Core.Dtos.TypeDefinitions
{
    public abstract class TypeDefinition
    {
        public string Name { get; set; }

        public MultilanguageStringDto Labels { get; set; }

        public abstract TypeKind TypeKind { get; }
    }
}