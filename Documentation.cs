using System;

class OldPhone
{
    public static string OldPhonePad(string input)
    {
        // phone keypad
        string[] keypad = new string[]
        {
            "", "", "ABC", "DEF", "GHI", "JKL", "MNO", "PQRS", "TUV", "WXYZ"
        };
        // variable to store the final output
        string result = "";
        // variable to store how many times a key is pressed
        string sequence = "";
        // loop every single character in the input
        foreach (char c in input)
        {
            // # to end the loop
            if (c == '#') break;
            // * to delete the sequence
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
            // ' ' to type two characters from the same button
            else if (c == ' ') {
                result += GetLetter(sequence, keypad);
                sequence = "";
            }
            // store the letters based on the sequence
            else {
                if (sequence.Length > 0 && sequence[0] != c)
                {
                    result += GetLetter(sequence, keypad);
                    sequence = "";
                }
                sequence += c;
            }
        }
        // build the output
        if (sequence.Length > 0)
        {
            result += GetLetter(sequence, keypad);
        }
        // return the final output
        return result;
    }

    private static string GetLetter(string sequence, string[] keypad)
    {
        // return if the sequence is empty
        if (string.IsNullOrEmpty(sequence)) return "";
        // convert char to int
        int key = sequence[0] - '0'; 
        // return if the sequence is not a number
        if (key < 2 || key > 9) return ""; 
        // found the letters based on the sequence
        string letters = keypad[key];
        // variable to store how many times they pressed a key
        int presses = sequence.Length;
        // variable to store how many letters are in a key
        int letterCount = letters.Length;
        // variable to calculate the correct letter based on the sequence pressed
        // example: 777 → presses = 3, letterCount = 4 ("PQRS"), so index = 2 → R
        int index = (presses - 1) % letterCount;
        // return correct letter
        return letters[index].ToString(); 
    }
}

class Program
{
    static void Main(string[] args)
    {
        // test cases
        Console.WriteLine(OldPhone.OldPhonePad("33#"));                     // Output: E
        Console.WriteLine(OldPhone.OldPhonePad("227*#"));                   // Output: B
        Console.WriteLine(OldPhone.OldPhonePad("4433555 555666#"));         // Output: HELLO
        Console.WriteLine(OldPhone.OldPhonePad("8 88777444666*664#"));      // Output: TURING
    }
}
