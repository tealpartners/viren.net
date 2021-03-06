﻿using System.Collections.Generic;

namespace Viren.Execution.Dtos.CalculationDtos.OptimizeDtos.Z3
{
    public class Z3FullResultDto : Z3ResultDto
    {
        public Dictionary<string, object> ResultProperties { get; set; }

        public Dictionary<string, object> Inputs { get; set; }
    }
}