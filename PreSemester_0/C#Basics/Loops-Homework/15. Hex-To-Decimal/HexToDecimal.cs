using System;
using System.Text.RegularExpressions;

class HexToDecimal
{
    static void Main()
    {
    start:
        Console.Write("Input hexadecimal number: ");
        string inputStr = Console.ReadLine().Trim().ToUpper();
        string patern = @"^[a-fA-F0-9]+$";
        if (!Regex.IsMatch(inputStr, patern))
        {
            Console.WriteLine("Invalid input! Only \"0\" and \"1\" is allowed!");
            goto start;
        }

        long decimalNumber = 0;
        for (int i = 0; i < inputStr.Length; i++)
        {
            switch (inputStr[i])
            {
                case 'A': decimalNumber += 10 * (long)Math.Pow(16, inputStr.Length - 1 - i); break;
                case 'B': decimalNumber += 11 * (long)Math.Pow(16, inputStr.Length - 1 - i); break;
                case 'C': decimalNumber += 12 * (long)Math.Pow(16, inputStr.Length - 1 - i); break;
                case 'D': decimalNumber += 13 * (long)Math.Pow(16, inputStr.Length - 1 - i); break;
                case 'E': decimalNumber += 14 * (long)Math.Pow(16, inputStr.Length - 1 - i); break;
                case 'F': decimalNumber += 15 * (long)Math.Pow(16, inputStr.Length - 1 - i); break;
                default: decimalNumber += (int)char.GetNumericValue(inputStr[i]) * (long)Math.Pow(16, inputStr.Length - 1 - i);
                    break;
            }

        }
        Console.WriteLine(decimalNumber);
    }
}
