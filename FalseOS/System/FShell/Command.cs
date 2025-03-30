using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FalseOS.System.FShell
{
    interface Command
    {
        public void Execute(String command, String[] words);
    }
}
