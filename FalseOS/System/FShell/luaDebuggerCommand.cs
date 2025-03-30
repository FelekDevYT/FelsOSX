using System;
using UniLua;
using NotImplementedException = System.NotImplementedException;

namespace FalseOS.System.FShell;

public class luaDebuggerCommand : Command
{
    public void Execute(string command, string[] words)
    {
        //debug your code
        while (true)
        {
            Console.Write("LUA debugger$ ");
            var state = Console.ReadLine();
            if (state == "$%")
            {
                break;
            }
            var luastate = LuaAPI.NewState();
            luastate.L_OpenLibs();
            luastate.L_DoString(state);
        }
    }
}