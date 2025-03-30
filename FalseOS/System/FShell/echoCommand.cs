using System;
using System.IO;
using NotImplementedException = System.NotImplementedException;

namespace FalseOS.System.FShell;

public class echoCommand : Command
{
    public void Execute(string command, string[] words)
    {
        if (words.Length > 1)
        {
            String wholeString = "";
            for (int i = 1; i < words.Length; i++)
            {
                wholeString += words[i] + " ";
            }

            int pathIndex = wholeString.LastIndexOf('>');
            String text = wholeString.Substring(0, pathIndex);
            String path = wholeString.Substring(pathIndex + 1);
            if (!path.Contains(@"\"))
                path = Kernel.Path + path;
            if (path.EndsWith(' '))
            {
                path = path.Substring(0, path.Length - 1);
            }
            File.Create(path);
            File.WriteAllText(path, text);
        }
        else
        {
            WriteMessage.writeError("Indalid syntax!");
        }
    }
}