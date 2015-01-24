using System;
using System.Collections.Generic;
using System.Linq;

class LongestArea
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string[] arr = new string[n];
        int index=new int();
        int count=0;
        int tempcount = 1;

        for (int i = 0; i < n; i++)
        {
            arr[i]=Console.ReadLine().Trim();
        }

        for (int i = 0; i < arr.Length; i++)
        {
            if (i<arr.Length-1)
            {
                if (arr[i]==arr[i+1])
                {
                    tempcount++;
                }
                else
                {
                    if (tempcount>count)
                    {
                        count = tempcount;
                        index = i + 1 - count;
                        tempcount = 1;
                    }
                }
            }
            else
            {
                if (tempcount > count)
                {
                    count = tempcount;
                    index = i + 1 - count;
                    tempcount = 1;
                }
            }
        }

        if (count>1)
        {
            Console.WriteLine();
            Console.WriteLine(count);
            for (int i = index; i < index+count; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }
        else
        {
            Console.WriteLine(1);
            Console.WriteLine(arr[0]);
        }
    }
}
