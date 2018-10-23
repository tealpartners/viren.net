using Viren.Client.Execution.Core.Dtos.General;

namespace Viren.Client.Execution.Core.Dtos.Globals
{
    public class ComplexGlobalValueReferenceDto
    {
        public string Name { get; set; }

        public MultilanguageStringDto Labels { get; set; }

        public string ComplexTypeName { get; set; }
    }
}