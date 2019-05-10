using Viren.Core.Enums;

namespace Viren.Core.Dtos
{
    public class ValidationMessage
    {
        public ValidationLevel ValidationLevel { get; set; }

        public string Code { get; set; }

        public string Message { get; set; }
    }
}