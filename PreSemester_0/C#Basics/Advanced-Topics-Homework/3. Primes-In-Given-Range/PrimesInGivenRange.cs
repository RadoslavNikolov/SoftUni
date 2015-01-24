using System;
using System.Collections.Generic;

class PrimeChecker
{
    static void Main()
    {
        Console.Write("Enter start number: ");
        int startNum = int.Parse(Console.ReadLine());
        Console.Write("Enter end number: ");
        int endNum = int.Parse(Console.ReadLine());

        List<int> primeList = new List<int>();
        primeList = IsPrime(startNum, endNum, primeList);
        string output = "";

        foreach (var item in primeList)
        {
            output += item + ", ";
        }
        Console.WriteLine(output.Trim(' ', ','));      
    }


    static List<int> IsPrime(int startNum, int endNum, List<int> primeList)
    {
        bool isPrime = new bool();
        
        for (int i = startNum; i <= endNum; i++)
        {
            for (int j = 2; j <= Math.Sqrt(i) + 1; j++)
            {
                if (i > 2 && i % j != 0)
                {
                    isPrime = true;
                }
                else if (i == 2)
                {
                    isPrime = true;
                    break;
                }
                else
                {
                    isPrime = false;
                    break;
                }
            }
            if (isPrime)
            {
                primeList.Add(i);
            }
        }
        return primeList;
    }
}
