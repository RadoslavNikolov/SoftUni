using System;
using System.Text.RegularExpressions;
class BinaryToDecimal
{
    static void Main()
    {
    start:
        Console.Write("Input binary number: ");
        string inputStr = Console.ReadLine().Trim();
        string patern = @"^[0-1]+$";
        if (!Regex.IsMatch(inputStr, patern))
        {
            Console.WriteLine("Invalid input! Only \"0\" and \"1\" is allowed!");
            goto start;
        }

        long result = 0;
        for (int i = 0, j = inputStr.Length - 1; i < inputStr.Length; i++, j--)
        {
            //int s=(int)char.GetNumericValue(inputStr[j]);
            result += ((long)char.GetNumericValue(inputStr[j]) * (long)Math.Pow(2, i));
        }
        Console.WriteLine(result);
    }
}
