using Viren.Core.Dtos;

namespace Viren.Execution.Requests
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