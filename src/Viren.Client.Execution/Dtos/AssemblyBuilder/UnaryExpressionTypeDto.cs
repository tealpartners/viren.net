namespace Viren.Client.Execution.Dtos.AssemblyBuilder
{
    public class UnaryExpressionTypeDto : ExpressionTypeDto
    {
        public string Operation { get; set; }
        public ExpressionTypeDto Expression { get; set; }

        public override ExpressionType ExpressionType => ExpressionType.Unary;
    }
}