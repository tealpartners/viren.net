using System.Collections.Generic;

namespace Viren.Core.Dtos.Admin
{
    public class UserDto : ProfileDto
    {
        public string Email { get; set; }

        public IList<UserRecentVersionDto> RecentVersions { get; set; }

        public string Language { get; set; }
    }
}