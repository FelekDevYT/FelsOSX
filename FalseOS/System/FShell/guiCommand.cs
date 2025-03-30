using Cosmos.System.Graphics;
using FalseOS.System.GUI;
using NotImplementedException = System.NotImplementedException;

namespace FalseOS.System.FShell;

public class guiCommand : Command
{
    public void Execute(string command, string[] words)
    {
        GUIupdate.start(Kernel.canv);
        Cosmos.System.MouseManager.ScreenWidth = 1280;
        Cosmos.System.MouseManager.ScreenHeight = 720;
        Kernel.GUI = true;
        GUIupdate.start(Kernel.canv);
    }
}