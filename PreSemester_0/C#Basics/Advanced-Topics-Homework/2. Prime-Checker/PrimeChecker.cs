using System;

class PrimeChecker
{
    static void Main()
    {
        long n = long.Parse(Console.ReadLine());
        Console.WriteLine("IsPrime({0}): {1}",n,IsPrime(n));
    }

    static bool IsPrime(long n)
    {
        bool isPrime = new bool();

        for (int i = 2; i <= Math.Sqrt(n)+1; i++)
        {
            if (n>2 && n%i!=0)
            {
                isPrime = true;
            }
            else if(n==2)
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

        return isPrime;
    }
}
