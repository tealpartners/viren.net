using System.Net.Http;
using System.Transactions;
using Viren.Core;
using Viren.Core.Helpers;
using Viren.Execution.Clients;
using Environment = Viren.Core.Enums.Environment;

namespace Viren.Execution
{
    public class ExecutionClient : IVirenExecutionClient
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="httpClient">inject http client(.NET CORE must use DI for httpClient)
        /// https://www.stevejgordon.co.uk/introduction-to-httpclientfactory-aspnetcore
        /// </param>
        public ExecutionClient(HttpClient httpClient)
        {
            Model = new ModelClient(httpClient);
            Calculation = new CalculationClient(httpClient, Model);
            InteractiveRun = new InteractiveRunClient(httpClient);
        }

        public ICalculationClient Calculation { get; }
        public IModelClient Model { get; }
        public IInteractiveRunClient InteractiveRun { get; }
    }
}