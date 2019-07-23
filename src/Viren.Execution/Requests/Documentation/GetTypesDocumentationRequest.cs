using System.Collections.Generic;
using Viren.Core.Dtos;
using Viren.Execution.Dtos.Documentation;

namespace Viren.Execution.Requests.Documentation
{
    public class GetTypesDocumentationRequest :IProjectModelVersion
    {
        public string Project { get; set; }
        public string Model { get; set; }
        public int Version { get; set; }
        public bool? Draft { get; set; }
        public string Language { get; set; }
    }


    public class GetTypesDocumentationResponse: BaseResponse
    {
        public GetTypesDocumentationResponse()
        {
            Types = new List<TypeDocumentationDto>();
        }

        public List<TypeDocumentationDto> Types { get; set; }
    }
}