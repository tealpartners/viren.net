using Viren.Core.Dtos;

namespace Calculation.Execution.Contracts.RequestResponses
{
    public abstract class BaseResponse
    {
        public ValidationBag ValidationBag { get; set; }

        public BaseResponse()
        {
            ValidationBag = new ValidationBag();
        }
    }
}