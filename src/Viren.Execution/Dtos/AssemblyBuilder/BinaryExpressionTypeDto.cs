namespace Viren.Execution.Dtos.AssemblyBuilder
{
    public class BinaryExpressionTypeDto : ExpressionTypeDto
    {
        public ExpressionTypeDto LeftExpression { get; set; }
        public ExpressionTypeDto RightExpression { get; set; }
        public string Operation { get; set; }

        public override ExpressionType ExpressionType => ExpressionType.Binary;
    }
}