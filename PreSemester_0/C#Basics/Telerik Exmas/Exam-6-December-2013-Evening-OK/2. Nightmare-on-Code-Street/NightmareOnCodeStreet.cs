using System;

class NightmareOnCodeStreet
{
    static void Main()
    {
        string inputStr = Console.ReadLine().Trim().ToLower();
        int sum = 0;
        int countOddElements = 0;

        for (int i = 0; i < inputStr.Length; i++)
        {
            if (inputStr[i]>='0' && inputStr[i]<='9')
            {
                if (i % 2 != 0)
                {
                    sum += (int)char.GetNumericValue(inputStr[i]);
                    countOddElements++;
                }
            }
            
        }
        Console.WriteLine("{0} {1}",countOddElements,sum);
    }
}
