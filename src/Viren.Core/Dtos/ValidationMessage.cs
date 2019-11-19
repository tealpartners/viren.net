using Viren.Core.Enums;

namespace Viren.Core.Dtos
{
    public class ValidationMessage
    {
        public ValidationMessage()
        {

        }

        public ValidationMessage(ValidationLevel validationLevel, string code, string message)
        {
            this.ValidationLevel = validationLevel;
            this.Code = code;
            this.Message = message;
        }


        public ValidationLevel ValidationLevel { get; set; }

        public string Code { get; set; }

        public string Message { get; set; }
    }
}