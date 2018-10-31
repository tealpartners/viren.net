namespace Viren.Execution.Clients
{
    public interface IVirenExecutionClient
    {
        ICalculationClient Calculation { get; }
        IModelClient Model { get; }
        IInteractiveRunClient InteractiveRun { get; }
    }
}