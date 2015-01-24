using System;
using System.Numerics;

class FibonacciNumbers
{
    static void Main()
    {
        Console.Write("Enter \"n\": ");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("Fibonacci Number of \"{0}\" is: {1}", n , Fib(n));
    }

    static  BigInteger Fib(int n)
    {
        BigInteger result = 1;
       
        int element1 = 0;
        int element2 = 1;
        for (int i = 0; i < n; i++)
        {
            element2 = element2 + element1;
            element1 = element2 - element1;               
        }
        return element2;
        
    }
}
