namespace Viren.Client.Execution.Dtos.AssemblyBuilder
{
    public abstract class ExpressionTypeDto
    {
        public abstract ExpressionType ExpressionType { get; }

        public string ResultTypeName { get; set; }

        public string UniqueKey { get; set; }
    }
}