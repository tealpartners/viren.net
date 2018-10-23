using Viren.Client.Execution.Core.Enums;

namespace Viren.Client.Execution.Core.Dtos.TypeDefinitions
{
    public class SingleKeyDto
    {
        public string PropertyName { get; set; }

        public KeyType KeyType => KeyType.Single;
    }
}