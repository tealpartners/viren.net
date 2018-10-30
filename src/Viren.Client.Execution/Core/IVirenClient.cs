using Viren.Client.Execution.Clients;

namespace Viren.Client.Execution.Core
{
    public interface IVirenClient
    {
        ICalculationClient Calculation { get; }
        IModelClient Model { get; }
        IInteractiveRunClient InteractiveRun { get; }
    }
}