using Viren.Client.Execution.Core.Dtos.General;
using Viren.Client.Execution.Core.Dtos.TypeValues;

namespace Viren.Client.Execution.Core.Dtos.Globals
{
    public class SystemGlobalValueDto
    {
        public string Name { get; set; }

        public MultilanguageStringDto Labels { get; set; }

        public SystemValueDto Value { get; set; }
    }
}