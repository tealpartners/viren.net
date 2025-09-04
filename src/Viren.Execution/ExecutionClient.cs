using System.Net.Http;
using Viren.Execution.Clients;

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
            Calculation = new CalculationClient(httpClient);
            Documentation = new DocumentationClient(httpClient);
        }

        public ICalculationClient Calculation { get; }
        public IModelClient Model { get; }
        public IDocumentationClient Documentation { get; }
    }
}