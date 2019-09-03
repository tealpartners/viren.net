using System.Collections.Generic;

namespace Viren.Execution.Dtos.Documentation
{
    public class BlockDocumentationParameterDto
    {
        public string Name { get; set; }

        public string TypeName { get; set; }
    }

    public class BlockDocumentationInputParameterDto : BlockDocumentationParameterDto
    {
        public string GlobalReference { get; set; }

        public string TagName { get; set; }
    }


    public class BlockDocumentationOutputParameterDto : BlockDocumentationParameterDto
    {
        public BlockDocumentationOutputParameterDto()
        {
            Tags=new List<string>();
        }

        public List<string> Tags { get; set; }
    }
}