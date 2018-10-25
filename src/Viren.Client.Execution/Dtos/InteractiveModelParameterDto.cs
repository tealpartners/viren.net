using Viren.Client.Execution.Core.Enums;

namespace Viren.Client.Execution.Dtos
{
    public class InteractiveModelParameterDto
    {
        public string BlockName { get; set; }
        public string Name { get; set; }
        public TypeKind TypeKind { get; set; }
        public string TypeName { get; set; }
        public object Value { get; set; }
        public bool IsInput { get; set; }
        public InteractiveModelParameterDto GlobalReference { get; set; }
    }
}