using Viren.Client.Execution.Core.Enums;

namespace Viren.Client.Execution.Core.Dtos.Admin
{
    public class AccessDto
    {
        public string Name { get; set; }

        public AccessLevel Level { get; set; }

        public AccessRight Right { get; set; }
    }
}