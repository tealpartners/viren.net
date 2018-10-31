using System.Collections.Generic;
using Viren.Core.Enums;

namespace Viren.Core.Dtos.TypeDefinitions
{
    public class TableTypeDto : TypeDefinition
    {
        public IList<PropertyInfoDto> Properties { get; set; }

        public IList<KeyDto> Keys { get; set; }

        public override TypeKind TypeKind => TypeKind.Table;
    }
}