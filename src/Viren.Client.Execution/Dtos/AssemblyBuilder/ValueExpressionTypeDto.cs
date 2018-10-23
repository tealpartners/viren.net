namespace Viren.Client.Execution.Dtos.AssemblyBuilder
{
    public class ValueExpressionTypeDto : ExpressionTypeDto
    {
        public object Value { get; set; }
        public override ExpressionType ExpressionType => ExpressionType.Value;
    }
}