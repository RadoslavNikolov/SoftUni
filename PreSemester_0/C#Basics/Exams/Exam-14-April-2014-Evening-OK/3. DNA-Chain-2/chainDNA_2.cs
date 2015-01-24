using System;

class chainDNA_2
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        char startLetter = Convert.ToChar(Console.ReadLine());
        int letterSequence = 1;
        int multiplier = 1;
        string dots = "";

        for (int i = 1; i <= n; i++)
        {
            dots = new string('.', (7 - letterSequence) / 2);
            Console.Write(dots);

            for (int j = 0; j < letterSequence; j++)
            {
                Console.Write(startLetter);
                startLetter = getLetter(startLetter);
            }
            Console.WriteLine(dots);

            if (i % 7 == 4)
            {
                multiplier = -multiplier;
                letterSequence = 5;
            } else if (i % 7 == 0)
            {
                letterSequence = 1;
                multiplier = -multiplier;
            }
            else
            {
                letterSequence += multiplier * 2;
            }          
        }
    }

    public static char getLetter(char c)
    {
        c++;
        c = c > 'G' ? 'A' : c;
        return c;
    }
}