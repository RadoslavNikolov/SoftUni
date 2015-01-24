using System;
using System.Collections.Generic;

class crossingSequenses
{
    static void Main()
    {
        long trib1 = long.Parse(Console.ReadLine());
        long trib2 = long.Parse(Console.ReadLine());
        long trib3 = long.Parse(Console.ReadLine());
        List<long> tribonacci=new List<long>();

        long number = long.Parse(Console.ReadLine());
        long step = long.Parse(Console.ReadLine());
        long trib = 0;
        bool success = false;

        tribonacci.Add(trib1);
        tribonacci.Add(trib2);
        tribonacci.Add(trib3);
        while (trib<=1000000)
        {
            trib = trib1 + trib2 + trib3;
            trib1 = trib2;
            trib2 = trib3;
            trib3 = trib;
            tribonacci.Add(trib);          
        }

        while (number<=1000000)
        {
            
            if (success=tribonacci.Contains(number))
            {
                Console.WriteLine(number);
                break;
            }
            number += step;
        }

        if (success==false)
        {
            Console.WriteLine("No");
        }
    }
}
