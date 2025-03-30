using FalseOS.System.programs;
using NotImplementedException = System.NotImplementedException;

namespace FalseOS.System.FShell;

public class notepadCommand : Command
{
    public void Execute(string command, string[] words)
    {
        Notepad.run();
    }
}