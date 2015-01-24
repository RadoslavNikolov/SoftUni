using System;

class printHouse
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            if (i==0)
            {
                string output = new string('.',n / 2) + new string('*',1) + new string('.',n / 2);
                Console.WriteLine(output);
            }
            else if (i > 0 && i < n/2)
            {
                string output = new string('.',(n - (i * 2 - 1) - 2) / 2) + new string('*',1) + new string('.',i * 2 - 1) +
                                new string('*', 1) + new string('.', (n - (i * 2 - 1) - 2) / 2);
                Console.WriteLine(output);
            }
            else if (i == n/2)
            {
                string output = new string('*', n);
                Console.WriteLine(output);
            }
            else if (i > n/2 && i < n - 1)
            {
                string output = new string('.', n / 4) + new string('*', 1) +
                                new string('.', n - (n / 4) * 2 - 2) + new string('*', 1) + new string('.', n / 4);
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
