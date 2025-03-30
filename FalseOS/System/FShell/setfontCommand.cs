using FalseOS.System.Font;
using NotImplementedException = System.NotImplementedException;

namespace FalseOS.System.FShell;

public class setfontCommand : Command
{
    public void Execute(string command, string[] words)
    {
        FontManager.parseAndSetFont(words[1]);
    }
}