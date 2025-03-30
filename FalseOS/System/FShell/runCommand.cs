using System;
using System.IO;
using UniLua;
using NotImplementedException = System.NotImplementedException;

namespace FalseOS.System.FShell;

public class runCommand : Command
{
    public void Execute(string command, string[] words)
    {
        try
        {
            String src = File.ReadAllText(Kernel.Path + words[1]);
            String dsrc = new SimpleCipher(92489945).Decrypt(src);
            var lua = LuaAPI.NewState();
            lua.L_OpenLibs();
            lua.L_DoString(dsrc);
        }
        catch(Exception exc)
        {
            WriteMessage.writeError(exc.ToString());
        }
    }
}