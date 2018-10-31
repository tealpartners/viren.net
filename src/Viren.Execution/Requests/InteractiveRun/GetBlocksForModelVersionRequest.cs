using System.Collections.Generic;
using Viren.Execution.Dtos;

namespace Viren.Execution.Requests.InteractiveRun
{
    public class GetBlocksForModelVersionRequest
    {
        public string Project { get; set; }
        public string Model { get; set; }
        public int Version { get; set; }
        public bool RootsOnly { get; set; }
        public bool? Draft { get; set; }
    }

    public class GetBlocksForModelVersionResponse
    {
        public List<IdTextStringDto> Blocks { get; set; }
    }
}