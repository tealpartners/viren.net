using Viren.Core.Dtos.General;
using Viren.Core.Enums;

namespace Viren.Core.Dtos.TypeDefinitions
{
    public abstract class TypeDefinition
    {
        public string Name { get; set; }

        public MultilanguageStringDto Labels { get; set; }

        public abstract TypeKind TypeKind { get; }
    }
}