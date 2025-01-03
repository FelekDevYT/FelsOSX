﻿using FalseOS.System;
using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.System.FileSystem;
using Sys = Cosmos.System;
using Cosmos.Core.Memory;
using Cosmos.System.Graphics.Fonts;
using Cosmos.System.Graphics;
using IL2CPU.API.Attribs;
using System.IO;
using System.Threading;

namespace FalseOS
{
    public class Kernel : Sys.Kernel
    {
        public static String ver = "0.0.0";
        public static String Path = @"0:\";
        public static CosmosVFS fs;

        protected override void BeforeRun()
        {
            WriteMessage.writeInfo("Pre-boot successfully!");
            fs = new CosmosVFS();
            WriteMessage.writeInfo("FileSystem has been created!");
            Cosmos.System.FileSystem.VFS.VFSManager.RegisterVFS(fs);
            WriteMessage.writeOk("FileSystem has been registering!");
            Console.OutputEncoding = Cosmos.System.ExtendedASCII.CosmosEncodingProvider.Instance.GetEncoding(437);
            WriteMessage.writeInfo("Set output format to EXTENDEDASCII");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Booting FelsOS " + ver);
            Console.ForegroundColor= ConsoleColor.White;

            WriteMessage.writeInfo("End of booting FelsOS");
        }


        protected override void Run()
        {
            try
            {
                Console.Write(Path + "> ");
                var command = Console.ReadLine();
                ConsoleCommands.RunCommand(command);
            }
            catch (Exception ex)
            {
                WriteMessage.writeCriticalErrorScreen(ex);
            }
        }

        protected override void AfterRun()
        {
            Thread.Sleep(500);
            WriteMessage.writeInfo("Shutting down os...");
        }
    }
}
