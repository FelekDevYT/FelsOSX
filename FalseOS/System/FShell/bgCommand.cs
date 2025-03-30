using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FalseOS.System.FShell
{
    public class bgCommand : Command
    {
        public void Execute(string command, string[] words)
        {
            Cosmos.System.Global.Console.Background = (ConsoleColor)Int32.Parse(words[1]);
            Console.Clear();
        }
    }
}
