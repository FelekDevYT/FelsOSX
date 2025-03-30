using Cosmos.System;
using Cosmos.System.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FalseOS.System.GUI
{
    public class FenixReader
    {
        public static string BreakLines(string inputString)
        {
            int lineLength = 128;

            StringBuilder result = new StringBuilder();
            for (int i = 0; i < inputString.Length; i += lineLength)
            {
                result.Append(inputString.Substring(i, Math.Min(lineLength, inputString.Length - i))); 
                if (i % lineLength == 0 && i != 0)
                {
                    result.Append("\n");
                }
            }

            return result.ToString();
        }

        public static String text = "FenixReader file content...";
        public static bool draw(Canvas c, Bitmap closeButtonTexture)
        {
            c.DrawFilledRectangle(Color.Gray, 0, 50, 1280, 670);

            c.DrawFilledRectangle(Color.DarkGray, 0, 50, 1280, 20);
            c.DrawString("FenixReaderX - 0.1 ==== "+ Kernel.Path, Cosmos.System.Graphics.Fonts.PCScreenFont.Default, Color.Black, 5, 55);

            c.DrawLine(Color.Black, 640, 50, 640, 720);
            c.DrawLine(Color.Black, 0, 335, 1280, 335);

            //Program logic

            int y = 70;

            foreach(String file in Directory.GetFiles(Kernel.Path))
            {
                Button btn = new Button(c,10,y,Color.Blue,file);
                if(btn.IsPressed((int)Cosmos.System.MouseManager.X, (int)Cosmos.System.MouseManager.Y))
                {
                    text = BreakLines(File.ReadAllText(Kernel.Path + file));
                }

                y += 20;
            }

            y = 70;

            foreach(String dir in Directory.GetDirectories(Kernel.Path))
            {
                Button btn = new Button(c, 645, y, Color.Blue, dir);
                if (btn.IsPressed((int)Cosmos.System.MouseManager.X, (int)Cosmos.System.MouseManager.Y))
                {
                    Kernel.Path += dir + "\\";
                }

                y += 20;
            }

            //exit button logic

            c.DrawString(text,
                Cosmos.System.Graphics.Fonts.PCScreenFont.Default,
                Color.Red, 20, 350);

            Button closeButton = new Button(c, 1260, 50, closeButtonTexture);
            if (closeButton.IsPressed((int)Cosmos.System.MouseManager.X, (int)Cosmos.System.MouseManager.Y))
            {
                return true;
            }

            return false;
        }
    }
}
