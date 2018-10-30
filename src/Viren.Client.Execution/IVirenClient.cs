using Viren.Client.Execution.Clients;

namespace Viren.Client.Execution
{
    public interface IVirenClient
    {
        ICalculationClient Calculation { get; }
        IModelClient Model { get; }
        IInteractiveRunClient InteractiveRunClient { get; }
    }
}