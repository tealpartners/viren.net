using System;
using System.Collections.Generic;

namespace Viren.Execution.Dtos.AssemblyBuilder
{
    public class ModelDebugParsingDto
    {
        public ModelDebugParsingDto()
        {
            Blocks = new List<ModelDebugParsingBlockDto>();
        }

        public string Id { get; set; }
        public ModelVersionDto ModelVersion { get; set; }
        public DateTime Created { get; set; }
        public List<ModelDebugParsingBlockDto> Blocks { get; set; }
    }
}