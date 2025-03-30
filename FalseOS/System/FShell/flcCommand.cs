using System;
using System.IO;
using NotImplementedException = System.NotImplementedException;

namespace FalseOS.System.FShell;

public class flcCommand : Command
{
    public void Execute(string command, string[] words)
    {
        switch (words[2])
        {
            case "-o":
                String src = File.ReadAllText(Kernel.Path + words[1]);
                String esrc = new SimpleCipher(92489945).Encrypt(src);
                File.WriteAllText(Kernel.Path + words[3],esrc);
                break;
            default:
                WriteMessage.writeError("Usage: flc --help or fcl -h for get command list!");
                break;
        }
    }
}