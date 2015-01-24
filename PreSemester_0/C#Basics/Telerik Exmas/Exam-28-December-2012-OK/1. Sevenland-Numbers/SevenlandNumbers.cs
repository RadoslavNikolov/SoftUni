using System;
using System.Collections.Generic;

class SevenlandNumbers
{
    static void Main()
    {
        int num = int.Parse(Console.ReadLine());
        int transmission = 0;
        int k = 1;
        List<int> output=new List<int>();
        num += k;
        while (true)
        {
            if ((num / 10 > 0) || (transmission!=0))
            {
                int tempNum = num % 10;
                if (transmission == 0)
                {
                    if (tempNum > 6)
                    {
                        output.Insert(0, 0);
                        transmission++;
                    }
                    else
                    {
                        output.Insert(0, tempNum);
                    }
                    num /= 10;
                }
                else
                {
                    tempNum += transmission;
                    transmission = 0;
                    if (tempNum > 6)
                    {
                        output.Insert(0, 0);
                        transmission++;
                    }
                    else
                    {
                        output.Insert(0, tempNum);
                    }
                    num /= 10;
                }
            }
            else if(num>0 && num <=9 )
            {
                int tempNum = num % 10;
                if (tempNum > 6)
                {
                    output.Insert(0, 0);
                    transmission++;
                    output.Insert(0, transmission);
                    transmission = 0;
                }
                else
                {
                    output.Insert(0, tempNum);
                }
                num /= 10;
            }
            else
            {
                break;
            }
        }

        foreach (var item in output)
        {
            Console.Write(item);
        }
        Console.WriteLine();
    }
}
