using Viren.Core.Enums;

namespace Viren.Execution.Dtos
{
    public class ParameterNameValueTypeDto
    {
        public string Name { get; set; }
        public string TypeName { get; set; }
        public TypeKind TypeKind { get; set; }
        public object Value { get; set; }
    }

    public class ResultPropertyNameValueTypeDto
    {
        public string Name { get; set; }
        public string TypeName { get; set; }
        public TypeKind TypeKind { get; set; }
        public object Value { get; set; }
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