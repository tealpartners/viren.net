using System.Collections.Generic;
using Viren.Core.Enums;

namespace Viren.Core.Dtos.TypeDefinitions
{
    public class ComplexTypeDto : TypeDefinition
    {
        public IList<PropertyInfoDto> Properties { get; set; }

        public override TypeKind TypeKind => TypeKind.Complex;
    }
}