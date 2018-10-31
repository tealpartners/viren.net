using Viren.Core.Enums;

namespace Viren.Core.Dtos
{
    public class ValidationMessage
    {
        public ValidationLevel ValidationLevel { get; }

        public string Code { get; }

        public string Message { get; }
    }
}