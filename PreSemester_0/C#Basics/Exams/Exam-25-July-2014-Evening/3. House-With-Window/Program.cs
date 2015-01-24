using System;


class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            if (i==0)
            {
                string output = new string('.', (2 * n - 2) / 2) + "*" + new string('.', (2 * n - 2) / 2);
                Console.WriteLine(output);
            }
            else
            {
                string output = new string('.', n - 1 - i) + "*" + new string('.', (2 * n - 1) - 2 - (n - 1 - i) * 2) + "*" + new string('.', n - 1 - i);
                Console.WriteLine(output);
            }
        }
        string output1 = new string('*', 2 * n - 1);
        Console.WriteLine(output1);

        for (int i = 1; i <=n; i++)
        {
            if (i<=n/4)
            {
                string output = "" + "*" + new string('.', 2 * n - 3) + "*";
                Console.WriteLine(output);
            }
            else if ( i>= n/4 && i <= (n/4)+(n/2))
            {
                string output = "" + "*" + new string('.', ((2 * n - 1) - 2 - (n - 3)) / 2) + new string('*', n - 3) + new string('.', ((2 * n - 1) - 2 - (n - 3)) / 2) + "*";
                Console.WriteLine(output);
            }
            else
            {
                string output = "" + "*" + new string('.', 2 * n - 3) + "*";
                Console.WriteLine(output);
            }
        }
        string output2 = new string('*', 2 * n - 1);
        Console.WriteLine(output2);
    }
}
