using System.Collections.Generic;

namespace Viren.Client.Execution.Dtos.AssemblyBuilder
{
    public class ModelDebugParsingBlockDto
    {
        public string BlockName { get; set; }
        public List<AssignmentLineDto> ExpressionLines { get; set; }

        public override string ToString()
        {
            return $"{nameof(BlockName)}: {BlockName}";
        }
    }
}