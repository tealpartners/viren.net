namespace Viren.Client.Execution.Dtos.AssemblyBuilder
{
    public class TernaryExpressionTypeDto : ExpressionTypeDto
    {
        public ExpressionTypeDto ConditionExpression { get; set; }
        public ExpressionTypeDto CaseTrueExpression { get; set; }
        public ExpressionTypeDto CaseFalseExpression { get; set; }

        public override ExpressionType ExpressionType => ExpressionType.Ternary;
    }
}