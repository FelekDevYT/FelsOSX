using System;
using System.IO;

namespace FalseOS.System.programs;

public class FASS
{
    public static void RunFile(String file)
    {
        String[] content = File.ReadAllLines(Kernel.Path + file);
        int exit_code = 0;
        
        foreach (String el in content)
        {
            String[] output = Execute_instruction(el);
            if (output[0] == "EXIT")
            {
                exit_code = Int32.Parse(output[1]);
                break;
            }
        }
        
        WriteMessage.writeInfo("FASS Exit code: " + exit_code);
    }
    
    public static String[] Execute_instruction(String instr)
    {
        String[] words = instr.Trim().Split(' ');
        try
        {
            switch (words[0])
            {
                case "HLT":
                    int opcode = Int32.Parse(words[1]);
                    return new string[] { "EXIT", opcode.ToString() };
                default:

                    break;
            }
        }
        catch (Exception e)
        {
            //Skip current line!!!
        }

        return new string[] { "EXT_HLT_ERR", "010" };
    }
}