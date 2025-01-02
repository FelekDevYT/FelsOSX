using System;
using System.Text;

namespace FalseOS.System;

public class SimpleCipher
{
    private int shift;

    public SimpleCipher(int shift)
    {
        this.shift = shift;
    }

    public string Encrypt(string input)
    {
        StringBuilder encrypted = new StringBuilder();

        foreach (char c in input)
        {
            char shiftedChar = (char)(c + shift);
            encrypted.Append(shiftedChar);
        }

        return encrypted.ToString();
    }

    public string Decrypt(string input)
    {
        StringBuilder decrypted = new StringBuilder();

        foreach (char c in input)
        {
            char shiftedChar = (char)(c - shift);
            decrypted.Append(shiftedChar);
        }

        return decrypted.ToString();
    }
}