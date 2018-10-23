using Viren.Client.Execution.Core.Dtos.General;
using Viren.Client.Execution.Core.Dtos.TypeValues;

namespace Viren.Client.Execution.Core.Dtos.Globals
{
    public class TableGlobalValueDto
    {
        public string Name { get; set; }

        public MultilanguageStringDto Labels { get; set; }

        public TableValueDto Value { get; set; }
    }
}