using Cosmos.System.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FalseOS.System.Font
{
    public class Font
    {
        public byte[] font;
        public int runByteCount;

        public Font(byte[] fo,int rbc) {
            font = fo;
            runByteCount = rbc;
        }

        public void setAsDefaultFont()
        {
            VGAScreen.SetFont(font, runByteCount);
        }
    }
}
