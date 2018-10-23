using Viren.Client.Execution.Core.Enums;

namespace Viren.Client.Execution.Core.Dtos
{
    public class ValidationMessage
    {
        public ValidationLevel ValidationLevel { get; }

        public string Code { get; }

        public string Message { get; }
    }
}