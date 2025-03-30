using Cosmos.System.Graphics.Fonts;
using Cosmos.System.Graphics;
using FalseOS.System.programs;
using FalseOS.System.utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using UniLua;
using FalseOS.System.Font;
using System.Reflection.PortableExecutable;
using Cosmos.System.Network.Config;
using Cosmos.System.Network.IPv4.UDP.DNS;
using Cosmos.System.Network.IPv4;
using CosmosHttp.Client;
using FalseOS.System.OSUtlis;
using System.Numerics;
using FalseOS.System.FShell;

namespace FalseOS.System;

/*
Black = 0,
DarkBlue = 1,
DarkGreen = 2,
DarkCyan = 3,
DarkRed = 4,
DarkMagenta = 5,
DarkYellow = 6,
Gray = 7,
DarkGray = 8,
Blue = 9,
Green = 10,
Cyan = 11,
Red = 12,
Magenta = 13,
Yellow = 14,
White = 15
*/

public class ConsoleCommands
{
    public static String[] args;

    public static void RunCommand(String command)
    {
        command = command.Trim();
        String[] words = command.Split(' ');
        if (words.Length > 0)
        {
            switch (words[0])
            {
                case "bg":
                    new bgCommand().Execute(command, words);
                    break;
                case "vm":
                    new vmCommand().Execute(command, words);
                    break;
                case "gui":
                    new guiCommand().Execute(command, words);
                    break;
                case "info":
                    new InfoCommand().Execute(command, words);
                    break;
                case "free":
                    long free = Kernel.fs.GetAvailableFreeSpace(Kernel.Path);
                    Console.WriteLine("Free space: " + free / 1024 + "KB");
                    break;
                case "ls":
                    new lsCommand().Execute(command, words);
                    break;
                case "echo":
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
                    break;
                case "cat":
                    new catCommand().Execute(command, words);
                    break;
                case "rm":
                    new rmCommand().Execute(command, words);
                    break;
                case "mkdir":
                    new mkdirCommand().Execute(command, words);
                    break;
                case "":
                    //PASS
                    break;
                case "mkfile":
                    new mkfileCommand().Execute(command, words);
                    break;
                case "cd":
                    new cdCommand().Execute(command, words);
                    break;
                case "lua":
                    new luaCommand().Execute(command, words);
                    break;
                case "clear":
                    new clearCommand().Execute(command, words);
                    break;
                case "shutdown":
                    new  shutdownCommand().Execute(command, words);
                    break;
                case "reboot":
                    new rebootCommand().Execute(command, words);
                    break;
                case "edit":
                    new editCommand().Execute(command, words);
                    break;
                case "notepad":
                    new notepadCommand().Execute(command, words);
                    break;
                case "calc":
                    new calcCommand().Execute(command, words);
                    break;
                case "luadebugger":
                    new luaDebuggerCommand().Execute(command, words);
                    break;
                case "set-font":
                    new setfontCommand().Execute(command, words);
                    break;
                case "fetch":
                    new fetchCommand().Execute(command, words);
                    break;
                case "sysinfo":
                    new sysInfoCommand().Execute(command, words);
                    break;
                case "cputest":
                    new cpuTestCommand().Execute(command, words);
                    break;
                case "diskmanager":
                    new diskmanagerCommand().Execute(command, words);
                    break;
                case "format":
                    new formatCommand().Execute(command, words);
                    break;
                case "flc"://fcl[0] test.l[1] -o[2] test.app[3]
                    new flcCommand().Execute(command, words);
                    break;
                case "run":
                    new runCommand().Execute(command, words);
                    break;
                case "wget":
                    new wgetCommand().Execute(command, words);
                    break;
                case "tl":
                    new thCommand().Execute("",words);
                    break;
                case "fass":
                    new fassCommand().Execute("", args);
                    break;
                default:
                    if (command.StartsWith("./"))
                    {
                        var a = command.Substring(2);
                        RunCommand(File.ReadAllText(Kernel.Path + a));
                    }
                    else
                    {
                        WriteMessage.writeError("Not found command or FSHELL handle applet!");
                    }
                    break;
            }
        }
    }
}