using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FalseOS.System.install
{
    public class Install
    {
        public static void login()
        {
            while(true){
                Console.Write("Enter username$ ");
                var name = Console.ReadLine();
                Console.Write("Enter password$ ");
                var pass = WriteMessage.nonWritingReadLine();

                if (name == "REINSTALL_OS") install();
                if(name == "SAFE") return;

                if (File.Exists(@"0:\FelsOS\users\" + name + ".user"))
                {
                    if (new SimpleCipher(12090764).Decrypt(File.ReadAllLines(@"0:\FelsOS\users\" + name + ".user")[0]) == pass)
                    {
                        break;
                    }
                    else
                    {
                        WriteMessage.writeError("Enter valid password!");
                    }
                }
            }
        }

        public static void install()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            WriteMessage.writeLogo();
            Console.WriteLine(WriteMessage.centerText("Welcome to FelsOS installer!"));
            Console.ForegroundColor = ConsoleColor.White;
            WriteMessage.writeInfo("Start installing...");
            Console.WriteLine("Starting installing in 5 seconds...");
            Thread.Sleep(5000);

            List<String> usernames = new List<string>();
            List<String> userpass = new List<string>();
            
            var superpass = "";
            bool quit = false;
            
            while (!quit)
            {
                Console.Clear();
                Console.WriteLine("Installing FelsOS");
                Console.WriteLine("------------------");

                Console.WriteLine("\nCommands:");
                Console.WriteLine("1. Register new user (r)");
                Console.WriteLine("2. Setup superuser password (s)");
                Console.WriteLine("3. quit and install (q)");

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.R:
                        Console.Clear();
                        Console.Write("Enter user name: ");
                        var username = Console.ReadLine();
                        Console.Write("Enter user password: ");
                        var pass = WriteMessage.nonWritingReadLine();
                        usernames.Add(username);
                        userpass.Add(pass);
                        WriteMessage.writeOk("Add new user!");
                        Thread.Sleep(1000);
                        break;
                    case ConsoleKey.S:
                        Console.Clear();
                        Console.Write("Enter superuser password: ");
                        superpass = WriteMessage.nonWritingReadLine();
                        WriteMessage.writeOk("Successfully set superuser password!");
                        Thread.Sleep(1000);
                        break;
                    case ConsoleKey.Q:
                        quit = true;
                        break;
                }
            }

            WriteMessage.writeInfo("Formatting harddrive disk");

            if (Kernel.fs.Disks[0].Partitions.Count > 0)
            {
                Kernel.fs.Disks[0].DeletePartition(0);
            }
            Kernel.fs.Disks[0].Clear();
            Kernel.fs.Disks[0].CreatePartition((int)(Kernel.fs.Disks[0].Size / (1024 * 1024)));
            Kernel.fs.Disks[0].FormatPartition(0, "FAT32", true);
            WriteMessage.writeOk("Successfully formatted harddrive OS");

            WriteMessage.writeInfo("Setting up directories...");

            Directory.CreateDirectory(@"0:\FelsOS\");
            Directory.CreateDirectory(@"0:\FelsOS\users\");

            WriteMessage.writeOk("Successfully settings up directories!");
            WriteMessage.writeInfo("Writing user settings...");

            for (int i = 0;i < usernames.Count;i++)
            {
                File.Create(@"0:\FelsOS\users\" + usernames[i]+".user");
                File.WriteAllText(@"0:\FelsOS\users\"+usernames[i]+".user",
                    new SimpleCipher(12090764).Encrypt(userpass[i]));
            }

            WriteMessage.writeOk("Successfully writted up user settings");

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            WriteMessage.writeLogo();
            Console.ForegroundColor = ConsoleColor.White;

            WriteMessage.writeOk("OS successfully installed!");
            WriteMessage.writeWarning("OS restart in 5 seconds...");
            Thread.Sleep(5000);
            Cosmos.System.Power.Reboot();
        }
    }
}
