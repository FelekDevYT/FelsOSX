using System;
using NotImplementedException = System.NotImplementedException;

namespace FalseOS.System.FShell;

public class clearCommand : Command
{
    public void Execute(string command, string[] words)
    {
        Console.Clear();
    }
}