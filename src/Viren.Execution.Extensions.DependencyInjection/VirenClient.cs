using System.Net.Http;
using Viren.Client.Execution.Clients;
using Viren.Client.Execution.Core;

namespace Viren.Execution.Extensions.DependencyInjection
{
    internal class VirenExecutionClient : IVirenExecutionClient
    {
        public VirenExecutionClient(HttpClient client)
        {
            Model = new ModelClient(client);
            Calculation = new CalculationClient(client, Model);
            InteractiveRun = new InteractiveRunClient(client);
        }

        public ICalculationClient Calculation { get; }
        public IModelClient Model { get; }
        public IInteractiveRunClient InteractiveRun { get; }
    }
}