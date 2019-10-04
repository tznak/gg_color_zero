using System;
using System.Diagnostics;
using System.Linq;
using static gg_color_zero.Kernel32;
using static gg_color_zero.Kernel32.AccessRights;

namespace gg_color_zero
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            const int online_skins = 0x1AC87B5;
            const AccessRights access_flags = PROCESS_VM_WRITE | PROCESS_VM_OPERATION;

            var processes = Process.GetProcessesByName("GuiltyGearXrd");
            if (processes.Length != 0 && processes[0]?.MainModule != null)
            {
                var process_handle = OpenProcess(access_flags, false, processes[0].Id);
                var base_address = processes[0].MainModule.BaseAddress;
                var skins = Enumerable.Repeat<byte>(0xFF, 25).ToArray();

                var bytes_written = 0;
                WriteProcessMemory
                (
                    process_handle,
                    base_address + online_skins,
                    skins, skins.Length,
                    ref bytes_written
                );

                Console.WriteLine("All online colors set to duplicate.");
            }
            else
            {
                Console.WriteLine("Could not find the Guilty Gear process.");
            }

            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}