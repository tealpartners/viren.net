using Viren.Core.Enums;

namespace Viren.Core.Dtos.Admin
{
    public class AccessDto
    {
        public string Name { get; set; }

        public AccessLevel Level { get; set; }

        public AccessRight Right { get; set; }
    }
}