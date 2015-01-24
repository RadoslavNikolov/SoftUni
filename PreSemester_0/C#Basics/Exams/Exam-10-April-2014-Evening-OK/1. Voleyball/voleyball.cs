using System;

class Voleyball
{
    static void Main(string[] args)
    {
        string typeOfYear = Console.ReadLine();
        int p = int.Parse(Console.ReadLine()); //holidays
        int h = int.Parse(Console.ReadLine()); //hometown
        if (typeOfYear == "leap")
        {
            double sumPlays = (p * 2 / 3.0 + h + (48 - h) * 3 / 4.0) * 1.15;
            Console.WriteLine((int)sumPlays);
        }
        else if (typeOfYear == "normal")
        {
            double sumPlays = (p * 2 / 3.0 + h + (48 - h) * 3 / 4.0);
            Console.WriteLine((int)sumPlays);
        }

    }
}
