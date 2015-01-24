using System;

class House
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int count = 1;
        for (int i = 1; i <= n; i++)
        {
            if (i == 1)
            {
                string output = new string('.', (n - 1) / 2) + new string('*', 1) + new string('.', (n - 1) / 2);
                Console.WriteLine(output);
            }
            else if (i > 1 && i < n / 2 + 1)
            {
                string output = new string('.', (n - 2 - count) / 2) + new string('*', 1) +
                                new string('.', count) + new string('*', 1) + new string('.', (n - 2 - count) / 2);
                Console.WriteLine(output);
                count += 2;
            }
            else if (i == n / 2 + 1)
            {
                string output = new string('*', n);
                Console.WriteLine(output);
            }
            else if (i > n / 2 + 1 && i < n)
            {
                string output = new string('.', n / 4) + new string('*', 1) +
                              new string('.', n - 2 - (n / 4) * 2) + new string('*', 1) + new string('.', n / 4);
                Console.WriteLine(output);
            }
            else
            {
                string output = new string('.', n / 4) + new string('*', n - (n / 4) * 2) + new string('.', n / 4);
                Console.WriteLine(output);
            }
        }
    }
}
