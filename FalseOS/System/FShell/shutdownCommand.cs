using NotImplementedException = System.NotImplementedException;

namespace FalseOS.System.FShell;

public class shutdownCommand : Command
{
    public void Execute(string command, string[] words)
    {
        Cosmos.System.Power.Shutdown();
    }
}