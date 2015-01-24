using System;


class Program
{
    static void Main()
    {
        char letter1 = Convert.ToChar(Console.ReadLine().ToUpper());
        char letter2 = Convert.ToChar(Console.ReadLine().ToUpper());
        int numOfRows = int.Parse(Console.ReadLine());
        int middleDistance = 0;
        char letter3;

        for (int i = 0; i < numOfRows; i++)
        {
            string output;
            if (i==0)
            {
                output = "" + letter1;
            }
            else if (i==1)
            {
                output = "" + letter2;
                letter3 = GetLetter(letter1, letter2);
                output += letter3;
                letter1 = letter2;
                letter2 = letter3;
            }
            else
            {
                middleDistance++;
                letter3 = GetLetter(letter1,letter2);
                output = "" + letter3 + new string(' ',middleDistance);
                letter1 = letter2;
                letter2 = letter3;
                letter3 = GetLetter(letter1, letter2);
                output += letter3;
                letter1 = letter2;
                letter2 = letter3;
            }
            Console.WriteLine(output);
        }
    }

    private static char GetLetter(char letter1, char letter2)
    {
        int sumLetters= ((int)letter1 - 64) + ((int)letter2 - 64);
        if (sumLetters > 26)
        {
            sumLetters %= 26;
        }
        char newLetter = (char)(sumLetters + 64);

        return newLetter;
    }
}
