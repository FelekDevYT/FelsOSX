using System;
using NotImplementedException = System.NotImplementedException;

namespace FalseOS.System.FShell;

public class fetchCommand : Command
{
    public void Execute(string command, string[] words)
    {
        Console.WriteLine($"" +
                          $"\t\t   ##,\r\n\t\t(##/#/((\r\n\t  ,#////(((((/\r\n\t  /*/*//##(*/*,\r\n   ,***/##*,**((( //*\r\n  ,* ,**/,    ,.*/* **,\r\n   *,*(,,,,*/***//*,/,\r\n\t .*,/,.,*((,,,/\r\n\t\t*/,,*/,*\r\n\t\t ,,/*/*\r\n\t\t\t*");
    }
}