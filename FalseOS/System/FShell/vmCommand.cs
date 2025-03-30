using NotImplementedException = System.NotImplementedException;

namespace FalseOS.System.FShell;

public class vmCommand : Command
{
    public void Execute(string command, string[] words)
    {
        if (Cosmos.System.VMTools.IsVirtualBox)
        {
            WriteMessage.writeInfo("VirtualMachine is VBox");
        }else if (Cosmos.System.VMTools.IsQEMU)
        {
            WriteMessage.writeInfo("VirtualMachine is QEMU");
        }else if (Cosmos.System.VMTools.IsVMWare)
        {
            WriteMessage.writeInfo("VirtualMachine is VMware");
        }
    }
}