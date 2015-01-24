using System;

class bonusScore
{
    static void Main()
    {
        int score = int.Parse(Console.ReadLine());
        if (score > 0 && score <= 3)
        {
            score *= 10;
            Console.WriteLine(score);
        }
        else if (score > 3 && score <= 6)
        {
            score *= 100;
            Console.WriteLine(score);
        }
        else if (score > 6 && score <= 9)
        {
            score *= 1000;
            Console.WriteLine(score);
        }
        else
        {
            Console.WriteLine("invalid score");
        }
    }
}
