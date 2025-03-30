using System;
using NotImplementedException = System.NotImplementedException;

namespace FalseOS.System.FShell;

public class InfoCommand : Command
{
    public void Execute(string command, string[] words)
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        WriteMessage.writeLogo();
        Console.WriteLine(WriteMessage.centerText("FelsOS"));
        Console.WriteLine(WriteMessage.centerText(Kernel.ver));
        Console.WriteLine(WriteMessage.centerText("Created by FelekDevYT"));
        Console.WriteLine(WriteMessage.centerText("https://github.com/FelekDevYT/"));
        Console.ForegroundColor = ConsoleColor.White;
    }
}