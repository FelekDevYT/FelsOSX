using System;
using System.IO;
using NotImplementedException = System.NotImplementedException;

namespace FalseOS.System.FShell;

public class cdCommand : Command
{
    public void Execute(string command, string[] words)
    {
        if (words.Length > 1)
        {
            if (words[1] == "*")
            {
                Kernel.Path = @"0:\";
            }
            if (words[1] == "..")
            {
                String tempPath = Kernel.Path.Substring(0, Kernel.Path.Length - 1);
                Kernel.Path = tempPath.Substring(0, tempPath.LastIndexOf(@"\"));
            }
            String path = words[1];
            if (!path.Contains(@"\"))
                path = Kernel.Path + path + @"\";
            if (path.EndsWith(' '))
            {
                path = path.Substring(0, path.Length - 1);
            }

            if (!(path.EndsWith(@"\")))
                path += @"\";
            if (Directory.Exists(path))
                Kernel.Path = path;
            else
                WriteMessage.writeError("Directory " + path + " not found!");
            WriteMessage.writeOk("Directory " + path + " created!");
        }
        else
        {
            WriteMessage.writeError("Indalid syntax");
        }
    }
}