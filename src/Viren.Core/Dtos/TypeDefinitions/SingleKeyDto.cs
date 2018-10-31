using Viren.Core.Enums;

namespace Viren.Core.Dtos.TypeDefinitions
{
    public class SingleKeyDto
    {
        public string PropertyName { get; set; }

        public KeyType KeyType => KeyType.Single;
    }
}