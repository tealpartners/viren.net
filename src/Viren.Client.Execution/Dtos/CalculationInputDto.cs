using System;
using System.Collections.Generic;

namespace Viren.Client.Execution.Dtos
{
    public class CalculationInputDto
    {
        public string RequestId = Guid.NewGuid().ToString();
        public IDictionary<string, object> Root { get; set; }
        public IDictionary<string, object> Globals { get; set; }
    }
}