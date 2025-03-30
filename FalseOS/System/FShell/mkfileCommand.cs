using System;
using System.IO;
using NotImplementedException = System.NotImplementedException;

namespace FalseOS.System.FShell;

public class mkfileCommand : Command
{
    public void Execute(string command, string[] words)
    {
        if (words.Length > 1)
        {
            String path = words[1];
            if (!path.Contains(@"\"))
                path = Kernel.Path + path;
            if (path.EndsWith(' '))
            {
                path = path.Substring(0, path.Length - 1);
            }

            File.Create(path);
            WriteMessage.writeOk("File " + path + " created!");
        }
        else
        {
            WriteMessage.writeError("Indalid syntax");
        }
    }
}