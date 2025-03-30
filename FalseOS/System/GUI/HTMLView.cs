using Cosmos.System.Graphics;
using Hrender3;
using HTMLRENDERER3.GrapeGL.Hrender3.DrawingUtils;
using IL2CPU.API.Attribs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace FalseOS.System.GUI
{
    public class HTMLView
    {
        [ManifestResourceStream(ResourceName = "FalseOS.fonts.MonaSans-Bold.ttf")]
        private static byte[] ariaMono;

        [ManifestResourceStream(ResourceName = "FalseOS.fonts.MonaSans-Regular.ttf")]
        private static byte[] ariaBold;

        public static bool draw(Canvas c, Bitmap closeButtonTexture)
        {
            c.DrawFilledRectangle(Color.Gray, 0, 50, 1280, 670);

            c.DrawFilledRectangle(Color.DarkGray, 0, 50, 1280, 20);
            c.DrawString("FRowser - 0.1", Cosmos.System.Graphics.Fonts.PCScreenFont.Default, Color.Black, 5, 55);

            //program logic
            var renderer = new htmlrender3(ariaMono, ariaBold); // create a renderer instance
            renderer.CustomTags.Add("list", (element, css) =>
            {

                String el = element.InnerHtml;
                String[] names = el.Split(";");
                String xPos = css.Position;

                int offset = 0;
                foreach (String name in names)
                {
                    renderer.staticrender.DrawString(name, 10, renderer.PageingOffset - 15 + offset, css.Color);
                    offset+=12;
                }

                renderer.PageingOffset += css.FontSize;
            });
            renderer.ParseHtml(Encoding.UTF8.GetString(Kernel.HTML));
            renderer.Update(1280,670); // update the view and set view resolution
            c.DrawImage(renderer.Render() /*Render the view to an image*/, 0,70);

            Button closeButton = new Button(c, 1260, 50, closeButtonTexture);
            if (!closeButton.IsPressed((int)Cosmos.System.MouseManager.X, (int)Cosmos.System.MouseManager.Y))
            {
                return true;
            }

            return false;
        }

    }
}
