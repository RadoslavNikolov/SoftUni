using System;

class countSymbols
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        char[] letters = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
        int[] weightLetters = {10,20,30,40,50,60,70,80,90,100,110,120,130,140,150,160,170,180,190,200,210,220,230,240,250,260};
        char[] symbols = { '`', '~', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+', '{', '}', ':', '"', '|', '<', '>', '?', '-', '=', '[', ']', ';', '\'', '\\', ',', '.', '/'};
        char[] digits = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
        int sumLetters = 0;
        int sumSymbols = 0;
        int sumDigits = 0;

        for (int i = 0; i < n; i++)
        {
            string inputStr = Console.ReadLine().ToLower();
            for (int j = 0; j < inputStr.Length; j++)
            {
                char element = inputStr[j];             
                for (int k = 0; k < letters.Length; k++)
                {
                    if (element==letters[k])
                    {
                        sumLetters += weightLetters[k];
                        continue;
                    }
                }

                for (int k = 0; k < symbols.Length; k++)
                {
                    if (element==symbols[k])
                    {
                        sumSymbols += 200;
                        continue;
                    }
                }

                for (int k = 0; k < digits.Length; k++)
                {
                    if (element==digits[k])
                    {
                        sumDigits += 20 * (int)char.GetNumericValue(digits[k]);
                        continue;
                    }
                }
            }
        }

        Console.WriteLine(sumLetters);
        Console.WriteLine(sumDigits);
        Console.WriteLine(sumSymbols);
    }
}
