using System;

namespace Viren.Client.Execution.Core.Enums
{
    [Flags]
    public enum AccessRight
    {
        None = 0, // 0x00
        Read = 1, // 0x01, 1 << 0
        Write = 2, // 0x02, 1 << 1
        Execute = 4, // 0x04, 1 << 2

        ReadWrite = Read | Write, // 0x03
        ReadExecute = Read | Execute, // 0x05
        WriteExecute = Write | Execute, //0x06
        ReadWriteExecute = ReadWrite | Execute // 0x07
    }
}