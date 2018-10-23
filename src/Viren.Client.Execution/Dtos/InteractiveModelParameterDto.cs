using Viren.Client.Execution.Core.Dtos.TypeValues;

namespace Viren.Client.Execution.Dtos
{
    public class InteractiveModelParameterDto
    {
        public string BlockName { get; set; }
        public string Name { get; set; }
        public ValueDefinition ValueDefinition { get; set; }
        public bool IsInput { get; set; }
        public InteractiveModelParameterDto GlobalReference { get; set; }
    }
}