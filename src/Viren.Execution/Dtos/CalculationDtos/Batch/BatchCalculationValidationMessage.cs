using Viren.Core.Dtos;
using Viren.Core.Enums;

namespace Viren.Execution.Dtos.CalculationDtos.Batch
{
    public class BatchCalculationValidationMessage : ValidationMessage
    {
        public BatchCalculationValidationMessage()
        {

        }

        public BatchCalculationValidationMessage(ValidationLevel validationLevel, string code, string message)
            : base(validationLevel, code, message)
        {

        }

        public int? BatchCalculationInputItemIndex { get; set; }
    }
}