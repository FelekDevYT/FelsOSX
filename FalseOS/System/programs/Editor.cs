using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FalseOS.System.utils
{
    public class Editor
    {
        public static void edit(String file)
        {
            String line = "";
            while (true)
            {
                String ln = Console.ReadLine();
                if(ln == "$%") break;
                line = line + "\n" + ln;
            }
            File.WriteAllText(file, line);
        }
    }
}
