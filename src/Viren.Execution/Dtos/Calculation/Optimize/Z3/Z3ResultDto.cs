using System.Collections.Generic;

namespace Viren.Execution.Dtos.Calculation.Optimize.Z3
{
    public class Z3ResultDto
    {
        public Dictionary<string, object> Results { get; set; }

        public bool Timeout { get; set; }

        public bool Unsat { get; set; }

        public int ElapsedMilliseconds { get; set; }
    }
}