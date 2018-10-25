using System.Collections.Generic;
using Viren.Client.Execution.Core.Dtos;
using Viren.Client.Execution.Dtos;

namespace Viren.Client.Execution.Requests.InteractiveRun
{
    public class GetInteractiveModelDataRequest: IProjectModelVersion
    {
        public string Project { get; set; }
        public string Model { get; set; }
        public int Version { get; set; }
        public string Block { get; set; }
        public bool? Draft { get; set; }
    }

    public class GetInteractiveModelDataResponse
    {
        public List<InteractiveModelResultPropertyDto> ResultProperties { get; set; }
        public List<InteractiveModelParameterDto> RootParameters { get; set; }
        public List<InteractiveModelParameterDto> Globals { get; set; }
        public string Project { get; set; }
        public string Model { get; set; }
        public int Version { get; set; }
        public string Block { get; set; }
        public int? Revision { get; set; }
    }
}