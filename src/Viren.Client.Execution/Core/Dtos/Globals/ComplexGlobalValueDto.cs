using Viren.Client.Execution.Core.Dtos.General;
using Viren.Client.Execution.Core.Enums;

namespace Viren.Client.Execution.Core.Dtos.Globals
{
    public class ComplexGlobalValueDto
    {
        public string Name { get; set; }

        public MultilanguageStringDto Labels { get; set; }

        public string TypeName { get; set; }

        public object[] Value { get; set; }

        public TypeKind TypeKind => TypeKind.Complex;
    }
}