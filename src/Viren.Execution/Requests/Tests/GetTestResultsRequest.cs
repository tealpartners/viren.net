using Viren.Execution.Dtos;

namespace Viren.Execution.Requests.Tests
{
    namespace Calculation.Execution.Contracts.RequestResponses.Models
    {
        public class GetTestResultsRequest
        {
            public string Project { get; set; }
            public string Model { get; set; }
            public int Version { get; set; }
        }

        public class GetTestResultsResponse
        {
            public string Project { get; set; }
            public TestResultsDto Results { get; set; }
        }
    }
}