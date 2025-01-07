using Cosmos.System;
using Cosmos.System.Graphics;
using IL2CPU.API.Attribs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FalseOS.System.GUI
{
    public class GUIupdate
    {
        [ManifestResourceStream(ResourceName = "FalseOS.assets.shut.bmp")]
        private static byte[] shutdownIcon;

        [ManifestResourceStream(ResourceName = "FalseOS.assets.reboot.bmp")]
        private static byte[] rebootIcon;


        private static bool isMenuOpened = false;
        public static void update(Canvas canv)
        {
            canv.Clear(Color.Black);

            canv.DrawFilledRectangle(Color.Aqua,0,0,1280,50);
            canv.DrawString(DateTime.Now.ToString(), Cosmos.System.Graphics.Fonts.PCScreenFont.Default, Color.Black,1120,2);

            buttons(canv);
            apps(canv);

            canv.DrawChar('#', Cosmos.System.Graphics.Fonts.PCScreenFont.Default, Color.Blue, (int)MouseManager.X, (int)MouseManager.Y);

            canv.Display();
        }

        private static void apps(Canvas canv)
        {
            if (isMenuOpened)
            {
                canv.DrawFilledRectangle(Color.LightGoldenrodYellow,0,50,400,600);

                Button shutdownButton = new Button(canv, 10, 60, new Bitmap(shutdownIcon));
                if (shutdownButton.IsPressed((int)MouseManager.X, (int)MouseManager.Y)){
                    Cosmos.System.Power.Shutdown();
                }

                Button rebootButton = new Button(canv,70,60,new Bitmap(rebootIcon));
                if(rebootButton.IsPressed((int)MouseManager.X, (int)MouseManager.Y))
                {
                    Cosmos.System.Power.Reboot();
                }
            }
        }

        [ManifestResourceStream(ResourceName = "FalseOS.assets.logo.bmp")]
        private static byte[] felsButton;

        private static void buttons(Canvas canv)
        {

            Button fels = new Button(canv, 0, 0, new Bitmap(felsButton));

            if(fels.IsPressed((int)MouseManager.X, (int)MouseManager.Y))
            {
                isMenuOpened = !isMenuOpened;
                Thread.Sleep(200);
            }
        }
    }
}
