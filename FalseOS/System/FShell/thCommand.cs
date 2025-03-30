using System;
using FalseOS.System.programs;
using NotImplementedException = System.NotImplementedException;

namespace FalseOS.System.FShell;

public class thCommand : Command
{
    public void Execute(string command, string[] words)
    {
        try
        { 
            TorchLang.Main(words[1]);
        }
        catch (Exception exc)
        {
            WriteMessage.writeError(exc.Message);
        }
    }
}