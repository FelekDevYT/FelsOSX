using FalseOS.System.utils;
using NotImplementedException = System.NotImplementedException;

namespace FalseOS.System.FShell;

public class editCommand : Command
{
    public void Execute(string command, string[] words)
    {
        Editor.edit(Kernel.Path + words[1]);
    }
}