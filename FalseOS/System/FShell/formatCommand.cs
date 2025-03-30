using System;
using System.Threading;
using NotImplementedException = System.NotImplementedException;

namespace FalseOS.System.FShell;

public class formatCommand : Command
{
    public void Execute(string command, string[] words)
    {
        if (words[1].StartsWith("FAT"))
        {
            if (Kernel.fs.Disks[0].Partitions.Count > 0)
            {
                Kernel.fs.Disks[0].DeletePartition(0);
            }
            Kernel.fs.Disks[0].Clear();
            Kernel.fs.Disks[0].CreatePartition((int)(Kernel.fs.Disks[0].Size / (1024 * 1024)));
            Kernel.fs.Disks[0].FormatPartition(0, words[1], true);
            WriteMessage.writeOk("Success format!");
            WriteMessage.writeWarning("FelsOS will be reboot in 3 seconds...");
            Thread.Sleep(3000);
            Cosmos.System.Power.Reboot();   
        }
        else
        {
            WriteMessage.writeError("Invalid syntax");
        }
    }
}