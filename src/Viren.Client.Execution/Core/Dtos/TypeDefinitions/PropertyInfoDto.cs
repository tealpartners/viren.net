using Viren.Client.Execution.Core.Dtos.General;

namespace Viren.Client.Execution.Core.Dtos.TypeDefinitions
{
    public class PropertyInfoDto
    {
        public string Name { get; set; }

        public string TypeName { get; set; }

        public MultilanguageStringDto Labels { get; set; }
    }
}