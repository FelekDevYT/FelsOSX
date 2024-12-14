using IL2CPU.API.Attribs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FalseOS.System.Font
{
    public class FontManager
    {
        [ManifestResourceStream(ResourceName = "FalseOS.fonts.1.F14")]
        public static byte[] FONT1;
        public static Font font1 = new Font(FONT1, 14);

        [ManifestResourceStream(ResourceName = "FalseOS.fonts.2.F12")]
        public static byte[] FONT2;
        public static Font font2 = new Font(FONT2, 12);

        [ManifestResourceStream(ResourceName = "FalseOS.fonts.3.F16")]
        public static byte[] FONT3;
        public static Font font3 = new Font(FONT3, 16);

        [ManifestResourceStream(ResourceName = "FalseOS.fonts.4.F20")]
        public static byte[] FONT4;
        public static Font font4 = new Font(FONT4, 20);

        [ManifestResourceStream(ResourceName = "FalseOS.fonts.5.F12")]
        public static byte[] FONT5;
        public static Font font5 = new Font(FONT5, 12);

        [ManifestResourceStream(ResourceName = "FalseOS.fonts.6.F16")]
        public static byte[] FONT6;
        public static Font font6 = new Font(FONT6, 16);

        [ManifestResourceStream(ResourceName = "FalseOS.fonts.7.F19")]
        public static byte[] FONT7;
        public static Font font7 = new Font(FONT7, 19);

        [ManifestResourceStream(ResourceName = "FalseOS.fonts.8.F16")]
        public static byte[] FONT8;
        public static Font font8 = new Font(FONT8, 16);

        [ManifestResourceStream(ResourceName = "FalseOS.fonts.9.F14")]
        public static byte[] FONT9;
        public static Font font9 = new Font(FONT9, 14);

        [ManifestResourceStream(ResourceName = "FalseOS.fonts.10.F08")]
        public static byte[] FONT10;
        public static Font font10 = new Font(FONT10, 8);

        [ManifestResourceStream(ResourceName = "FalseOS.fonts.11.F16")]
        public static byte[] FONT11;
        public static Font font11 = new Font(FONT11, 16);

        [ManifestResourceStream(ResourceName = "FalseOS.fonts.12.F08")]
        public static byte[] FONT12;
        public static Font font12 = new Font(FONT12, 8);

        [ManifestResourceStream(ResourceName = "FalseOS.fonts.13.F16")]
        public static byte[] FONT13;
        public static Font font13 = new Font(FONT13, 16);
        public static void parseAndSetFont(string font)
        {
            switch (font)
            {
                case "1":
                    font1.setAsDefaultFont();
                    break;
                case "2":
                    font2.setAsDefaultFont();
                    break;
                case "3":
                    font3.setAsDefaultFont();
                    break;
                case "4":
                    font4.setAsDefaultFont();
                    break;
                case "5":
                    font5.setAsDefaultFont();
                    break;
                case "6":
                    font6.setAsDefaultFont();
                    break;
                case "7":
                    font7.setAsDefaultFont();
                    break;
                case "8":
                    font8.setAsDefaultFont();
                    break;
                case "9":
                    font9.setAsDefaultFont();
                    break;
                case "10":
                    font10.setAsDefaultFont();
                    break;
                case "11":
                    font11.setAsDefaultFont();
                    break;
                case "12":
                    font12.setAsDefaultFont();
                    break;
                case "13":
                    font13.setAsDefaultFont();
                    break;
            }
        }
    }
}
