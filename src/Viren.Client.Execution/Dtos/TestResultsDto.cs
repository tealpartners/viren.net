using Viren.Client.Execution.Core.Dtos.TypeValues;

namespace Viren.Client.Execution.Dtos
{
    public class ParameterNameValueTypeDto
    {
        public string Name { get; set; }
        public ValueDefinition ValueDefinition { get; set; }
    }

    public class ResultPropertyNameValueTypeDto
    {
        public string Name { get; set; }
        public ValueDefinition ValueDefinition { get; set; }
    }

    public class TestResultDto
    {
        public string BlockName { get; set; }
        public string TestId { get; set; }
        public bool Passed { get; set; }
        public string ExecutionId { get; set; }
        public ParameterNameValueTypeDto[] Outputs { get; set; }
        public ResultPropertyNameValueTypeDto[] ResultProperties { get; set; }
    }

    public class TestResultsDto
    {
        public string Project { get; set; }
        public string Model { get; set; }
        public int Number { get; set; }
        public TestResultDto[] Results { get; set; }
        public bool Done { get; set; }
    }
}