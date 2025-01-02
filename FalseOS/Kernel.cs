using FalseOS.System;
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
<<<<<<< HEAD
using System.Threading;
using FalseOS.System.install;
using FalseOS.System.Protection;
=======
using FalseOS.System.install;
>>>>>>> 109e0f0be15fceab36d1c9b1ce5c549a00486f44

namespace FalseOS
{
    public class Kernel : Sys.Kernel
    {
        public static String ver = "0.0.0";
        public static String Path = @"0:\";
        public static CosmosVFS fs;
        public static OSRootProtection perms = new OSRootProtection(false,false,false);

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
<<<<<<< HEAD
            Thread.Sleep(500);
=======
>>>>>>> 109e0f0be15fceab36d1c9b1ce5c549a00486f44
            WriteMessage.writeInfo("Shutting down os...");
        }
    }
}
