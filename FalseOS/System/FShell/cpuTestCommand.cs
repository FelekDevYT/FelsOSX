using System;
using System.Threading;
using NotImplementedException = System.NotImplementedException;

namespace FalseOS.System.FShell;

public class cpuTestCommand : Command
{
    public void Execute(string command, string[] words)
    {
        ulong cpuUptime = Cosmos.Core.CPU.GetCPUUptime();
        WriteMessage.writeInfo("Starting tests");
        Thread.Sleep(1000);
        ulong afterCpuUptime = Cosmos.Core.CPU.GetCPUUptime();
        WriteMessage.writeOk("Ending CPUUptime tests");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine((double)(afterCpuUptime - cpuUptime) / 1000000000);
        Console.ForegroundColor = ConsoleColor.White;
    }
}