namespace Viren.Execution.Clients
{
    public interface IVirenExecutionClient
    {
        ICalculationClient Calculation { get; }
        IModelClient Model { get; }
        IDocumentationClient Documentation { get; }
    }
}