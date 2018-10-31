namespace Viren.Execution.Dtos.AssemblyBuilder
{
    public class AssignmentLineDto : ExpressionLineDto
    {
        public VariableDefinitionDto Target { get; set; }
        public ParseResultDto ParseResult { get; set; }
    }
}