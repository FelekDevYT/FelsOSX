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

namespace FalseOS.System;

public class ConsoleCommands
{
    public static void RunCommand(String command)
    {
        String[] words = command.Split(' ');
        if (words.Length > 0)
        {
            switch (words[0])
            {
                case "info":
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    WriteMessage.writeLogo();
                    Console.WriteLine(WriteMessage.centerText("FelsOS"));
                    Console.WriteLine(WriteMessage.centerText(Kernel.ver));
                    Console.WriteLine(WriteMessage.centerText("Created by FelekDevYT"));
                    Console.WriteLine(WriteMessage.centerText("https://github.com/FelekDevYT/"));
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case "free":
                    long free = Kernel.fs.GetAvailableFreeSpace(Kernel.Path);
                    Console.WriteLine("Free space: " + free / 1024 + "KB");
                    break;
                case "ls":
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
                    if (words.Length > 1)
                    {
                        String path = words[1];
                        if (!path.Contains(@"\"))
                            path = Kernel.Path + path;
                        if (path.EndsWith(' '))
                            path = path.Substring(0, path.Length - 1);
                        String text = File.ReadAllText(path);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine(text);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        WriteMessage.writeError("Indalid syntax");
                    }
                    break;
                case "rm":
                    String FULL_PATH = Kernel.Path + words[1];
                    if (File.Exists(FULL_PATH)) File.Delete(FULL_PATH);
                    else if (Directory.Exists(FULL_PATH))
                    {
                        try
                        {
                            if (words[2] == "-r")
                            {
                                Directory.Delete(FULL_PATH, true);
                                break;
                            }
                        }
                        catch (Exception ex) { }
                        Directory.Delete(FULL_PATH,false);
                    }
                    else
                    {
                        WriteMessage.writeError("Not found file or directory!");
                    }
                    break;
                case "mkdir":
                    if (words.Length > 1)
                    {
                        String path = words[1];
                        if (!path.Contains(@"\"))
                            path = Kernel.Path + path;
                        if (path.EndsWith(' '))
                        {
                            path = path.Substring(0, path.Length - 1);
                        }

                        Directory.CreateDirectory(path);
                        WriteMessage.writeOk("Directory " + path + " created!");
                    }
                    else
                    {
                        WriteMessage.writeError("Indalid syntax");
                    }
                    break;
                case "mkfile":
                    if (words.Length > 1)
                    {
                        String path = words[1];
                        if (!path.Contains(@"\"))
                            path = Kernel.Path + path;
                        if (path.EndsWith(' '))
                        {
                            path = path.Substring(0, path.Length - 1);
                        }

                        File.Create(path);
                        WriteMessage.writeOk("File " + path + " created!");
                    }
                    else
                    {
                        WriteMessage.writeError("Indalid syntax");
                    }
                    break;
                case "cd":
                    if (words.Length > 1)
                    {
                        if (words[1] == "..")
                        {
                            String tempPath = Kernel.Path.Substring(0, Kernel.Path.Length - 1);
                            Kernel.Path = tempPath.Substring(0, tempPath.LastIndexOf(@"\"));
                        }
                        String path = words[1];
                        if (!path.Contains(@"\"))
                            path = Kernel.Path + path + @"\";
                        if (path.EndsWith(' '))
                        {
                            path = path.Substring(0, path.Length - 1);
                        }

                        if (!(path.EndsWith(@"\")))
                            path += @"\";
                        if (Directory.Exists(path))
                            Kernel.Path = path;
                        else
                            WriteMessage.writeError("Directory " + path + " not found!");
                        WriteMessage.writeOk("Directory " + path + " created!");
                    }
                    else
                    {
                        WriteMessage.writeError("Indalid syntax");
                    }
                    break;
                case "lua":
                    try
                    {
                        var lua = LuaAPI.NewState();
                        lua.L_OpenLibs();
                        lua.L_DoString(File.ReadAllText(Kernel.Path + words[1]));
                    }
                    catch (Exception e)
                    {
                        WriteMessage.writeError(e.Message);
                    }
                    break;
                case "clear":
                    Console.Clear();
                    break;
                case "shutdown":
                    Cosmos.System.Power.Shutdown();
                    break;
                case "reboot":
                    Cosmos.System.Power.Reboot();
                    break;
                case "edit":
                    Editor.edit(Kernel.Path + words[1]);
                    break;
                case "notepad":
                    Notepad.run();
                    break;
                case "calc":
                    String expression = "";
                    for (int i = 1; i < words.Length; i++)
                    {
                        expression += words[i];
                    }
                    var luaAPI = LuaAPI.NewState();
                    luaAPI.L_OpenLibs();
                    luaAPI.L_DoString("print(" + expression + ")");
                    break;
                case "luadebugger":
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
                    break;
                case "set-font":
                    FontManager.parseAndSetFont(words[1]);
                    break;
                case "sysinfo":
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("CPU: {0}\nCPU vendor: {1}\n" +
                        "amoundOfRAM: {2}\navailiableRAM: {3}\n" +
                        "usedRAM: {4}",
                        Cosmos.Core.CPU.GetCPUBrandString(),
                        Cosmos.Core.CPU.GetCPUVendorName(),
                        Cosmos.Core.CPU.GetAmountOfRAM(),
                        Cosmos.Core.GCImplementation.GetAvailableRAM(),
                        Cosmos.Core.GCImplementation.GetUsedRAM());
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case "cputest":
                    ulong cpuUptime = Cosmos.Core.CPU.GetCPUUptime();
                    WriteMessage.writeInfo("Starting tests");
                    Thread.Sleep(1000);
                    ulong afterCpuUptime = Cosmos.Core.CPU.GetCPUUptime();
                    WriteMessage.writeOk("Ending CPUUptime tests");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine((double)(afterCpuUptime - cpuUptime) / 1000000000);
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case "diskmanager":
                    switch (words[1])
                    {
                        case "--list":
                        case "-l":
                            if (Kernel.fs.Disks.Count == 0)
                            {
                                WriteMessage.writeError("No disks found!");
                            }
                            for (int disk = 0; disk < Kernel.fs.Disks.Count; disk++)
                            {
                                Console.Write($"Disk {disk}");
                                Console.Write(new string(' ', 20 - $"Disk {disk}".Length));
                                Console.Write($"Size: {Kernel.fs.Disks[disk].Size / (1024 * 1024)}MiB");
                                Console.Write(new string(' ', 20 - $"Size: {Kernel.fs.Disks[disk].Size / (1024 * 1024)} MiB".Length));
                                Console.Write($"Partitions: {Kernel.fs.Disks[disk].Partitions.Count}");
                                Console.Write(new string(' ', 20 - $"Partitions: {Kernel.fs.Disks[disk].Partitions.Count}".Length));

                                if (Kernel.fs.Disks[disk].IsMBR)
                                    Console.Write($"MBR");
                                else
                                    Console.Write($"GPT");
                                Console.WriteLine();
                            }
                            break;
                    }
                    break;
                case "format":
                    if (Kernel.fs.Disks[0].Partitions.Count > 0)
                    {
                        Kernel.fs.Disks[0].DeletePartition(0);
                    }
                    Kernel.fs.Disks[0].Clear();
                    Kernel.fs.Disks[0].CreatePartition((int)(Kernel.fs.Disks[0].Size / (1024 * 1024)));
                    Kernel.fs.Disks[0].FormatPartition(0, "FAT32", true);
                    WriteMessage.writeOk("Success format!");
                    WriteMessage.writeWarning("FelsOS will be reboot in 3 seconds...");
                    Thread.Sleep(3000);
                    Cosmos.System.Power.Reboot();
                    break;
                case "install":
                    install.Install.install();
                    break;
                case "setsize":
                    Console.SetWindowSize(80,25);
                    break;
            }

            if (command.StartsWith("./"))
            {
                var a = command.Substring(2);
                RunCommand(File.ReadAllText(Kernel.Path + a));
            }
        }
    }
}