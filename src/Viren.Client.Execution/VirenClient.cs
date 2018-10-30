using System.Net.Http;
using Viren.Client.Execution.Clients;

namespace Viren.Client.Execution
{
    class VirenClient : IVirenClient
    {
        public VirenClient(HttpClient client)
        {
            Model = new ModelClient(client);
            Calculation = new CalculationClient(client, Model);
            InteractiveRunClient = new InteractiveRunClient(client);
        }
        public ICalculationClient Calculation { get; }
        public IModelClient Model { get; }
        public IInteractiveRunClient InteractiveRunClient { get; }
    }
}