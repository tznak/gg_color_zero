using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace gg_color_zero
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public static class Kernel32
    {
        [Flags]
        public enum AccessRights
        {
            PROCESS_VM_OPERATION = 0x0008,
            PROCESS_VM_READ      = 0x0010,
            PROCESS_VM_WRITE     = 0x0020
        }
        
        [DllImport("kernel32.dll")] public static extern IntPtr OpenProcess(AccessRights dwDesiredAccess, bool bInheritHandle, int dwProcessId);
        [DllImport("kernel32.dll")] public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int nSize, ref int lpNumberOfBytesRead);
        [DllImport("kernel32.dll")] public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int nSize, ref int lpNumberOfBytesWritten);
    }
}