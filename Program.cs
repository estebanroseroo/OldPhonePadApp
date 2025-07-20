using System;

class OldPhone
{
    public static string OldPhonePad(string input)
    {
        string[] keypad = new string[]
        {
            "", "", "ABC", "DEF", "GHI", "JKL", "MNO", "PQRS", "TUV", "WXYZ"
        };
        string result = "";
        string sequence = "";
        foreach (char c in input)
        {
            if (c == '#') break;
            if (c == '*') {
                if (sequence.Length > 0)
                {
                    sequence = "";
                }
                else if (result.Length > 0)
                {
                    result = result.Substring(0, result.Length - 1);
                }
            } 
            else if (c == ' ') {
                result += GetLetter(sequence, keypad);
                sequence = "";
            }
            else {
                if (sequence.Length > 0 && sequence[0] != c)
                {
                    result += GetLetter(sequence, keypad);
                    sequence = "";
                }
                sequence += c;
            }
        }
        if (sequence.Length > 0)
        {
            result += GetLetter(sequence, keypad);
        }
        return result;
    }

    private static string GetLetter(string sequence, string[] keypad)
    {
        if (string.IsNullOrEmpty(sequence)) return "";
        int key = sequence[0] - '0'; 
        if (key < 2 || key > 9) return ""; 
        string letters = keypad[key];
        int presses = sequence.Length;
        int letterCount = letters.Length;
        int index = (presses - 1) % letterCount;
        return letters[index].ToString(); 
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(OldPhone.OldPhonePad("33#"));                     // Output: E
        Console.WriteLine(OldPhone.OldPhonePad("227*#"));                   // Output: B
        Console.WriteLine(OldPhone.OldPhonePad("4433555 555666#"));         // Output: HELLO
        Console.WriteLine(OldPhone.OldPhonePad("8 88777444666*664#"));      // Output: TURING
    }
}
