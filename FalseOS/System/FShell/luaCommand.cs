using System;
using System.IO;
using UniLua;
using NotImplementedException = System.NotImplementedException;

namespace FalseOS.System.FShell;

public class luaCommand : Command
{
    public void Execute(string command, string[] words)
    {
        try
        {
            int ai = 0;
            for (int i = 2; i < words.Length; i++)
            {
                words[ai] = words[i];
                ai++;
            }
            var lua = LuaAPI.NewState();
            lua.L_OpenLibs();
            lua.L_DoString(File.ReadAllText(Kernel.Path + words[1]));
        }
        catch (Exception e)
        {
            WriteMessage.writeError(e.Message);
        }
    }
}