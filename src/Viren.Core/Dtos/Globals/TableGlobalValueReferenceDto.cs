using System.Collections.Generic;
using Viren.Core.Dtos.General;
using Viren.Core.Dtos.TypeDefinitions;

namespace Viren.Core.Dtos.Globals
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