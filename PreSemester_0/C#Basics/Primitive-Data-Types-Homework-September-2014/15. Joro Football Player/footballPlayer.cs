using System;


class footballPlayer
{
    static void Main()
    {
        string leapYear = Console.ReadLine();
        short p = short.Parse(Console.ReadLine()); //holidays
        byte h = byte.Parse(Console.ReadLine());   //hometown
        double sum = p / 2 + ((52 - h) / 3.0) * 2 + h;

        if (leapYear == "t")
        {
            sum += 3;
        }

        Console.WriteLine((int)sum);
        //The condition is wrong. Joro plays twice in the "normal" weekends but not when he is tired. 
        //He is tired in 1/3 of the normal weekends. 
        //That means he plays twice in 2/3 of the "normal" weekends or ((52-h)*2/3)*2 not ((52-h)*2/3).
    }
}
