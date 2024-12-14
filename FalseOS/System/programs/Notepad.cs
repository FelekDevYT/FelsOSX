using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FalseOS.System.programs
{
    public class Notepad
    {
        public static void run()
        {
            List<string> lines = new List<string>();
            int currentLine = 0;
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("Console Notepad");
                Console.WriteLine("------------------");

                for (int i = 0; i < lines.Count; i++)
                {
                    if (i == currentLine)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"> {lines[i]}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"  {lines[i]}");
                    }
                }

                Console.WriteLine("\nCommands:");
                Console.WriteLine("1. Add a new line (A)");
                Console.WriteLine("2. Move up (W)");
                Console.WriteLine("3. Move down (E)");
                Console.WriteLine("4. Delete current line (D)");
                Console.WriteLine("5. Save current file (S)");
                Console.WriteLine("5. Exit (Q)");

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.A:
                        Console.Clear();
                        Console.Write("Enter a new line: ");
                        string newLine = Console.ReadLine();
                        lines.Add(newLine);
                        currentLine = lines.Count - 1;
                        break;

                    case ConsoleKey.W:
                        if (currentLine > 0)
                        {
                            currentLine--;
                        }
                        break;

                    case ConsoleKey.E:
                        if (currentLine < lines.Count - 1)
                        {
                            currentLine++;
                        }
                        break;

                    case ConsoleKey.D:
                        if (lines.Count > 0)
                        {
                            lines.RemoveAt(currentLine);
                            if (currentLine >= lines.Count)
                            {
                                currentLine = lines.Count - 1;
                            }
                        }
                        break;

                    case ConsoleKey.Q:
                        running = false;
                        break;
                    case ConsoleKey.S:
                        Console.Clear();
                        Console.Write("Enter the filename to save: ");
                        string filename = Console.ReadLine();
                        try
                        {
                            String line = "";
                            foreach (String el in lines)
                            {
                                line += "\n" + el;
                            }
                            Console.WriteLine(line);
                            File.WriteAllText(Kernel.Path + filename, line);
                            WriteMessage.writeOk($"File '{filename}' saved successfully!");
                        }
                        catch (Exception ex)
                        {
                            WriteMessage.writeError($"Error saving file: {ex.Message}");
                        }
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
