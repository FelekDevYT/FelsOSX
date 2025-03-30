using System;
using NotImplementedException = System.NotImplementedException;

namespace FalseOS.System.FShell;

public class freeCommand : Command
{
    public void Execute(string command, string[] words)
    {
        long free = Kernel.fs.GetAvailableFreeSpace(Kernel.Path);
        Console.WriteLine("Free space: " + free / 1024 + "KB");
    }
}