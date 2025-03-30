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

namespace FalseOS.System.FShell;

public class lsCommand : Command
{
    public void Execute(string command, string[] words)
    {
        var Dirs = Directory.GetDirectories(Kernel.Path);
        var Files = Directory.GetFiles(Kernel.Path);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Directories (" + Dirs.Length + ")");
        Console.ForegroundColor = ConsoleColor.Gray;
        for (int i = 0; i < Dirs.Length; i++)
        {
            Console.WriteLine(Dirs[i]);
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Files (" + Files.Length + ")");
        Console.ForegroundColor = ConsoleColor.Gray;
        for (int i = 0; i < Files.Length; i++)
        {
            Console.WriteLine(Files[i]);
        }
    }
}