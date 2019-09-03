using System.Collections.Generic;
using Viren.Core.Enums;

namespace Viren.Execution.Dtos.CalculationDtos.Batch
{
    public class BatchCalculationInputItemDto 
    {
        public BatchCalculationInputItemDto()
        {
            Project = string.Empty;
            Model = string.Empty;
            EntryPoint = string.Empty;
            CalculationInputs = new List<CalculationInputDto>();
        }

        public string Project { get; set; }

        public string Model { get; set; }

        public int Version { get; set; }

        public int? Revision { get; set; }

        public string EntryPoint { get; set; }

        public bool? Debug { get; set; }

        public ResultType? ResultType { get; set; }

        public IList<CalculationInputDto> CalculationInputs { get; set; }
    }
}