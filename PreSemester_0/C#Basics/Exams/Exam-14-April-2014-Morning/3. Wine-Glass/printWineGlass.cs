using System;

class printWineGlass
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            if (i==0)
            {
                string output = new string('\\', 1) + new string('*', n - 2) + new string('/', 1);
                Console.WriteLine(output);
            }
            else if (i>0 && i<n/2-1)
            {
                string output = new string('.',i) + new string('\\', 1) + new string('*', n - 2 * i - 2) + new string('/', 1) + new string('.',i);
                Console.WriteLine(output);
            }
            else if (i==n/2-1)
            {
                string output = new string('.', (n - 2) / 2) + new string('\\', 1) + new string('/', 1) + new string('.', (n - 2) / 2);
                Console.WriteLine(output);
            }


            if (n<12)
            {
                if (i>n/2-1 && i<n-1)
                {
                    string output = new string('.', n / 2 - 1) + new string('|', 2) + new string('.', n / 2 - 1);
                    Console.WriteLine(output);
                }
                else if (i==n-1)
                {
                    string output = new string('-', n);
                    Console.WriteLine(output);
                }
            }
            else
            {
                if (i>n/2-1 && i<n-2)
                {
                    string output = new string('.', n / 2 - 1) + new string('|', 2) + new string('.', n / 2 - 1);
                    Console.WriteLine(output);
                }
                else if(i>=n-2)
                {
                    string output = new string('-', n);
                    Console.WriteLine(output);
                }
            }
        }
    }
}
