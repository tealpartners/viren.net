using System;
using System.Collections.Generic;
using Viren.Core.Dtos;

namespace Viren.Execution.Dtos
{
    public class ExecutedCalculationDto
    {
        public ModelVersionDto ModelVersion { get; set; }
        public string Id { get; set; }
        public DateTime ExecutionBegin { get; set; }
        public DateTime ExecutionEnd { get; set; }

        public object Result { get; set; }
        public bool IsValid { get; set; }
        public IList<ValidationMessage> ValidationMessages { get; set; }
        public Dictionary<string, object> Root { get; set; }
    }
}