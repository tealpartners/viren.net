using System.Collections.Generic;
using Viren.Client.Execution.Core.Enums;

namespace Viren.Client.Execution.Core.Dtos.TypeDefinitions
{
    public class ComplexTypeDto : TypeDefinition
    {
        public IList<PropertyInfoDto> Properties { get; set; }

        public override TypeKind TypeKind => TypeKind.Complex;
    }
}