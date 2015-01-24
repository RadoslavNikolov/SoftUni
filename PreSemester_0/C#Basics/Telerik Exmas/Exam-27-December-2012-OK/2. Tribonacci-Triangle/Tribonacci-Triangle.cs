using System;

class Program
{
    static void Main()
    {
        long num1 = long.Parse(Console.ReadLine());
        long num2 = long.Parse(Console.ReadLine());
        long num3 = long.Parse(Console.ReadLine());
        int numOfLines = int.Parse(Console.ReadLine());
        int tempCount = 1;
        int tribonacciCount = 1;

        for (int row = 0; row < numOfLines; row++)
        {
            for (int coll = 0; coll < tempCount; coll++)
            {
                if (tribonacciCount == 1)
                {
                    Console.Write("{0} ",num1);
                }
                else if (tribonacciCount == 2)
                {
                    Console.Write("{0} ", num2);
                }
                else if (tribonacciCount == 3)
                {
                    Console.Write("{0} ", num3);
                }
                else
                {
                    long tribonacciNum = num1 + num2 + num3;
                    num1 = num2;
                    num2 = num3;
                    num3 = tribonacciNum;
                    Console.Write("{0} ", num3);
                }
                tribonacciCount++;
            }
            Console.WriteLine();
            tempCount++;
        }
    }
}
