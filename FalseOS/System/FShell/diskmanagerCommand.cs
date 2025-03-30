using System;
using NotImplementedException = System.NotImplementedException;

namespace FalseOS.System.FShell;

public class diskmanagerCommand : Command
{
    public void Execute(string command, string[] words)
    {
        switch (words[1])
        {
            case "--list":
            case "-l":
                if (Kernel.fs.Disks.Count == 0)
                {
                    WriteMessage.writeError("No disks found!");
                }
                for (int disk = 0; disk < Kernel.fs.Disks.Count; disk++)
                {
                    Console.Write($"Disk {disk}");
                    Console.Write(new string(' ', 20 - $"Disk {disk}".Length));
                    Console.Write($"Size: {Kernel.fs.Disks[disk].Size / (1024 * 1024)}MiB");
                    Console.Write(new string(' ', 20 - $"Size: {Kernel.fs.Disks[disk].Size / (1024 * 1024)} MiB".Length));
                    Console.Write($"Partitions: {Kernel.fs.Disks[disk].Partitions.Count}");
                    Console.Write(new string(' ', 20 - $"Partitions: {Kernel.fs.Disks[disk].Partitions.Count}".Length));

                    if (Kernel.fs.Disks[disk].IsMBR)
                        Console.Write($"MBR");
                    else
                        Console.Write($"GPT");
                    Console.WriteLine();
                }
                break;
        }
    }
}