using System;
using UniLua;
using NotImplementedException = System.NotImplementedException;

namespace FalseOS.System.FShell;

public class calcCommand : Command
{
    public void Execute(string command, string[] words)
    {
        String expression = "";
        for (int i = 1; i < words.Length; i++)
        {
            expression += words[i];
        }
        var luaAPI = LuaAPI.NewState();
        luaAPI.L_OpenLibs();
        luaAPI.L_DoString("print(" + expression + ")");
    }
}