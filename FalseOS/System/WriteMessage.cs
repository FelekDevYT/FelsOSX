using System;

namespace FalseOS.System;

public class WriteMessage
{
    public static void writeError(String msg)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("[Error] ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(msg);
    }
    
    public static void writeWarning(String msg)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("[Warning] ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(msg);
    }
    
    public static void writeInfo(String msg)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("[Info] ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(msg);
    }
    
    public static void writeOk(String msg)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("[OK] ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(msg);
    }

    public static void writeLogo()
    {
        Console.WriteLine(
            centerText("\n ________ _______   ___       ________  ________  ________      \n|\\  _____\\\\  ___ \\ |\\  \\     |\\   ____\\|\\   __  \\|\\   ____\\     \n\\ \\  \\__/\\ \\   __/|\\ \\  \\    \\ \\  \\___|\\ \\  \\|\\  \\ \\  \\___|_    \n \\ \\   __\\\\ \\  \\_|/_\\ \\  \\    \\ \\_____  \\ \\  \\\\\\  \\ \\_____  \\   \n  \\ \\  \\_| \\ \\  \\_|\\ \\ \\  \\____\\|____|\\  \\ \\  \\\\\\  \\|____|\\  \\  \n   \\ \\__\\   \\ \\_______\\ \\_______\\____\\_\\  \\ \\_______\\____\\_\\  \\ \n    \\|__|    \\|_______|\\|_______|\\_________\\|_______|\\_________\\\n                                \\|_________|        \\|_________|\n                                                                \n                                                                \n"));
    }

    public static String centerText(String text)
    {
        int cw = 90;
        int padding = (cw - text.Length) / 2;
        String ct = text.PadLeft(padding + text.Length).PadRight(cw);
        return ct;
    }

    public static void writeCriticalErrorScreen(Exception ex)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("CRITICAL ERROR");
        Console.WriteLine("THE ERROR STATEMENT " + ex);
        Console.WriteLine("CRITICAL ERROR THROW CALL TREE:\n" + ex);
        Console.WriteLine("FELSOS SHOULD BE REBOOT FOR FIX CRITICAL ERROR");
        Console.Write("Press any key to reboot");
        Console.ReadKey();
        Cosmos.System.Power.Reboot();
    }

    public static String nonWritingReadLine()
    {
        String readLine = "";
        while (true)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Enter)
            {
                break;
            }
            readLine += key.KeyChar.ToString();
        }
        Console.WriteLine();
        return readLine;
    }
}