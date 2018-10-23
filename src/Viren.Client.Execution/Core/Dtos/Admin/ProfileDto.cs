using System.Collections.Generic;

namespace Viren.Client.Execution.Core.Dtos.Admin
{
    public abstract class ProfileDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public IList<AccessDto> Accesses { get; set; }
    }
}