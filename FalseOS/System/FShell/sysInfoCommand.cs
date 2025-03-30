using System;
using NotImplementedException = System.NotImplementedException;

namespace FalseOS.System.FShell;

public class sysInfoCommand : Command
{
    public void Execute(string command, string[] words)
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("CPU: {0}\nCPU vendor: {1}\n" +
                          "amoundOfRAM: {2}\navailiableRAM: {3}\n" +
                          "usedRAM: {4}",
            Cosmos.Core.CPU.GetCPUBrandString(),
            Cosmos.Core.CPU.GetCPUVendorName(),
            Cosmos.Core.CPU.GetAmountOfRAM(),
            Cosmos.Core.GCImplementation.GetAvailableRAM(),
            Cosmos.Core.GCImplementation.GetUsedRAM());
        Console.ForegroundColor = ConsoleColor.White;
    }
}