using System.Net.Http;
using Viren.Client.Execution.Clients;

namespace Viren.Client.Execution.Core
{
    internal class VirenClient : IVirenClient
    {
        internal VirenClient(HttpClient client)
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