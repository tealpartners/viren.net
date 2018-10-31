using Viren.Core.Dtos.General;
using Viren.Core.Enums;

namespace Viren.Core.Dtos.Globals
{
    public class SystemGlobalValueDto
    {
        public string Name { get; set; }

        public MultilanguageStringDto Labels { get; set; }

        public string TypeName { get; set; }

        public object Value { get; set; }

        public TypeKind TypeKind => TypeKind.System;
    }
}