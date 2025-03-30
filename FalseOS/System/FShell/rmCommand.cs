using System;
using System.IO;
using NotImplementedException = System.NotImplementedException;

namespace FalseOS.System.FShell;

public class rmCommand : Command
{
    public void Execute(string command, string[] words)
    {
        String FULL_PATH = Kernel.Path + words[1];
        if (File.Exists(FULL_PATH)) File.Delete(FULL_PATH);
        else if (Directory.Exists(FULL_PATH))
        {
            try
            {
                if (words[2] == "-r")
                {
                    Directory.Delete(FULL_PATH, true);
                    return;
                }
            }
            catch (Exception ex) { }
            Directory.Delete(FULL_PATH, false);
        }
        else
        {
            WriteMessage.writeError("Not found file or directory!");
        }
    }
}