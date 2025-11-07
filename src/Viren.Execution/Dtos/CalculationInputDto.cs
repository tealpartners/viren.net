using System;
using System.Collections.Generic;

namespace Viren.Execution.Dtos
{
    public class CalculationInputDto
    {
        public CalculationInputDto()
        {
            RequestId = Guid.NewGuid().ToString();
        }

        public string RequestId { get; set; }
        public bool IsTest { get; set; }
        public IDictionary<string, object> Root { get; set; }
        public IDictionary<string, object> Globals { get; set; }
    }
}