using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

class SecretsOfNumbers
{
    static void Main()
    {
        string input = Console.ReadLine();
        MatchCollection newMatch = Regex.Matches(input, "[0-9]");
        byte[] number = new byte[newMatch.Count];
        BigInteger specialSum = 0;
        string output = "";

        if (newMatch.Count>0)
	    {
            for (int i = 0; i < newMatch.Count; i++)
            {
                number[i] = Convert.ToByte(newMatch[i].Value);
            }

            Array.Reverse(number);

            for (int i = 0; i < number.Length; i++)
            {
                if ((i+1)%2!=0)
                {
                    specialSum += number[i] * (int)Math.Pow(i + 1, 2);
                }
                else
                {
                    specialSum += (int)Math.Pow(number[i], 2) * (i + 1);
                }
            }
	    }
        Console.WriteLine(specialSum);
        if (specialSum%10==0)
        {
            Console.WriteLine("{0} has no secret alpha-sequence", input);
        }
        else
        {
            int r = (int)(specialSum % 26);
            char ch = (char)('A'+r);
            
            for (int i = 0; i < (int)(specialSum%10); i++)
            {
                if (ch>'Z')
                {
                    ch = 'A';
                }
                output += ch;
                ch++;
            }
        }
        Console.WriteLine(output);
    }
}

