namespace Viren.Client.Execution.Dtos.AssemblyBuilder
{
    public class IdentifierExpressionTypeDto : ExpressionTypeDto
    {
        public string Name { get; set; }

        public override ExpressionType ExpressionType => ExpressionType.Identifier;
    }
}