using System;

class eclipse
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        for (int i = 1; i <= n; i++)
        {
            if (i == 1 || i == n)
            {
                string line = new string(' ', 1) + new string('*', 2 * n - 2) +
                              new string(' ', n+1) + new string('*', 2 * n - 2) + new string(' ', 1);
                Console.WriteLine(line);
            }
            else if (i==n/2+1)
            {
                string line = new string('*', 1) + new string('/', 2 * n - 2) + new string('*', 1) + new string('-', n - 1) +
                              new string('*', 1) + new string('/', 2 * n - 2) + new string('*', 1);
                Console.WriteLine(line);
            }
            else
            {
                string line = new string('*', 1) + new string('/', 2 * n - 2) + new string('*', 1) + new string(' ', n - 1) +
                              new string('*', 1) + new string('/', 2 * n - 2) + new string('*', 1);
                Console.WriteLine(line);
            }
        }
    }
}

