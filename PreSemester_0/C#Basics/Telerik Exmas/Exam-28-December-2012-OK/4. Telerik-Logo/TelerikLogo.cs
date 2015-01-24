using System;

class TelerikLogo
{
    static void Main()
    {
        int x = int.Parse(Console.ReadLine());
        int middleDots = (x - 2) * 2 + 1;
        int outerDots = x / 2;
        int secondMiddleDots = 1;

        for (int i = 0; i < x-1; i++)
        {
            string output = "";
            if (i == 0)
            {
                output += new string('.', outerDots) + "*" + new string('.', middleDots) + "*" + new string('.', outerDots);
                middleDots -= 2;
                outerDots--;
            }
            else if (i>0 && i<=x/2)
            {
                output += new string('.', outerDots) + "*" + new string('.', secondMiddleDots) + "*" + new string('.', middleDots) + "*" + new string('.', secondMiddleDots) + "*" + new string('.', outerDots);
                secondMiddleDots += 2;
                outerDots--;
                middleDots -= 2;
            }
            else
            {
                output += new string('.', secondMiddleDots) + "*" + new string('.', middleDots) + "*" + new string('.', secondMiddleDots);
                secondMiddleDots ++;
                middleDots -= 2;
            }
            Console.WriteLine(output);
        }

        for (int i = 0; i < 2 * x - 1; i++)
        {
            string output = "";
            if (i == 0)
            {
                output += new string('.', secondMiddleDots) + "*" + new string('.', secondMiddleDots);
                middleDots = 1;
                secondMiddleDots--;
            }
            else if (i > 0 && i < x)
            {
                output += new string('.', secondMiddleDots) + "*" + new string('.',middleDots) + "*" +  new string('.', secondMiddleDots);
                if (i<x-1)
                {
                    secondMiddleDots--;
                    middleDots += 2;  
                }
            }
            else if (i >= x && i < 2*x-2)
            {
                secondMiddleDots++;
                middleDots -= 2;
                output += new string('.', secondMiddleDots) + "*" + new string('.', middleDots) + "*" + new string('.', secondMiddleDots);
            }
            else
            {
                secondMiddleDots++;                
                output += new string('.', secondMiddleDots) + "*" + new string('.', secondMiddleDots);
            }
            Console.WriteLine(output);
        }
    }
}
