using System;

namespace Viren.Client.Execution.Core.Dtos.Admin
{
    public class UserRecentVersionDto
    {
        public string Project { get; set; }

        public string Model { get; set; }

        public int Version { get; set; }

        public DateTime LastOpened { get; set; }
    }
}