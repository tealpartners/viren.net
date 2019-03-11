using System.Collections.Generic;

namespace Viren.Execution.Dtos.Calculation.Optimize
{
    public class OptimizeAttempt
    {
        public decimal Difference { get; set; }
        public List<decimal> Inputs { get; set; }
        public decimal Result { get; set; }
        public decimal NextJump { get; set; }
        public bool NextJumpIsFast { get; set; }
        public bool NextJumpIsDivided { get; set; }
    }
}