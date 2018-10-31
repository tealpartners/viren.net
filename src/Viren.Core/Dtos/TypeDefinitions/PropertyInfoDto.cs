using Viren.Core.Dtos.General;

namespace Viren.Core.Dtos.TypeDefinitions
{
    public class PropertyInfoDto
    {
        public string Name { get; set; }

        public string TypeName { get; set; }

        public MultilanguageStringDto Labels { get; set; }
    }
}