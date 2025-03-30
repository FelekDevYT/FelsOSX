using System;
using System.IO;
using FalseOS.System.OSUtlis;
using NotImplementedException = System.NotImplementedException;

namespace FalseOS.System.FShell;

public class wgetCommand : Command
{
    public void Execute(string command, string[] words)
    {
        string url = words[1];

        try
        {
            string file = HttpHandler.downloadFile(url);
            File.WriteAllText(Kernel.Path + "file", file);
            WriteMessage.writeOk("URL contains saved to file");
        }
        catch (Exception ex)
        {
            WriteMessage.writeError(ex.ToString());
        }
    }
}