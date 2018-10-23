using System;
using Viren.Client.Execution.Core.Enums;

namespace Viren.Client.Execution.Core.Dtos.TypeValues
{
    public class SystemValueDto : ValueDefinition
    {
        public object Value { get; set; }

        public SystemType SystemType
        {
            get
            {
                var parsed = Enum.TryParse(TypeName, true, out SystemType systemType);
                if (!parsed) throw new InvalidOperationException();

                return systemType;
            }
            set => TypeName = value.ToString();
        }

        public override TypeKind TypeKind => TypeKind.System;
    }
}