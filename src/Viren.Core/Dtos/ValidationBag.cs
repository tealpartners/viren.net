using System.Collections.Generic;

namespace Viren.Core.Dtos
{
    public class ValidationBag
    {
        public ValidationBag()
        {
            Messages = new List<ValidationMessage>();
            IsValid = true;
        }
    
        public IList<ValidationMessage> Messages { get; set; }

        public bool IsValid { get; set; }
    }
}