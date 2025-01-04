using Cosmos.System.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FalseOS.System.GUI
{
    public class GUIupdate
    {
        public static void update(Canvas canv)
        {
            canv.Display();

            canv.Clear(Color.Aqua);
        }
    }
}
