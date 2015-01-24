using System;

class printSunglasses
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        for (int i = 1; i <= n; i++)
        {
            if (i==1 || i==n)
            {
                printMetod1(2*n,n);
                Console.WriteLine();
            }
            else if (i==(n+1)/2)
            {
                printMetod2(2*n-2);

                for (int j = 0; j < n; j++)
                {
                    Console.Write("|");
                }

                printMetod2(2 * n - 2);
                Console.WriteLine();
            }
            else
            {
                printMetod2(2 * n - 2);
                for (int j = 0; j < n; j++)
                {
                    Console.Write(" ");
                }
                printMetod2(2 * n - 2);
                Console.WriteLine();
            }
        }
    }

    private static void printMetod2(int slopLines)
    {
        Console.Write("*");

        for (int i = 0; i < slopLines; i++)
        {
            Console.Write("/");
        }

        Console.Write("*");
    }

    private static void printMetod1(int asteriskses, int spaces)
    {
        for (int i = 0; i < asteriskses; i++)
        {
            Console.Write("*");
        }
        for (int i = 0; i < spaces; i++)
        {
            Console.Write(" ");
        }
        for (int i = 0; i < asteriskses; i++)
        {
            Console.Write("*");           
        }
    }
}
