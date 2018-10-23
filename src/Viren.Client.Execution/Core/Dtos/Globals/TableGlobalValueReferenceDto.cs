using System.Collections.Generic;
using Viren.Client.Execution.Core.Dtos.General;
using Viren.Client.Execution.Core.Dtos.TypeDefinitions;

namespace Viren.Client.Execution.Core.Dtos.Globals
{
    public class TableGlobalValueReferenceDto
    {
        public string Name { get; set; }

        public MultilanguageStringDto Labels { get; set; }

        public string TableTypeName { get; set; }

        public IList<HistoricRangeDto> HistoricValues { get; set; }

        public RangeKeyDto HistoricColumn { get; set; }

        public SingleKeyDto _ { get; set; }
    }
}