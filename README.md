# Old Phone Pad

This C# program simulates typing letters using an old-style mobile phone keypad.

## How It Works
- Numbers 2 to 9 correspond to letters on a traditional phone keypad:
  - 2 → ABC
  - 3 → DEF
  - 4 → GHI
  - 5 → JKL
  - 6 → MNO
  - 7 → PQRS
  - 8 → TUV
  - 9 → WXYZ

- Pressing a key multiple times selects a different letter from that key.
  - Example: 2 → A, 22 → B, 222 → C

- * correspond to backspace key
- ' ' you must use space in order to type two characters from the same button
  - Example: 222 2 → CA
- # must be included at the end of every input

## Test Cases
OldPhonePad("33#") → E  
OldPhonePad("227*#") → B  
OldPhonePad("4433555 555666#") → HELLO  
OldPhonePad("8 88777444666*664#") → TURING  

# Usage
- Clone the repository: 
- Open it in Visual Studio Code
- Run the program using the command 'dotnet run'
