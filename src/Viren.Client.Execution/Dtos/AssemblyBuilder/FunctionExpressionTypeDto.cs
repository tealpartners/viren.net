namespace Viren.Client.Execution.Dtos.AssemblyBuilder
{
    public class FunctionExpressionTypeDto : ExpressionTypeDto
    {
        public string Name { get; set; }
        public ExpressionTypeDto[] Arguments { get; set; }

        public override ExpressionType ExpressionType => ExpressionType.Function;
    }
}