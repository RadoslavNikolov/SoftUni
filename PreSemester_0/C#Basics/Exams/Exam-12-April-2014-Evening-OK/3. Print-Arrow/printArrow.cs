using System;

class printArrow
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int count = 0;
        for (int i = 1; i <= 2*n-1; i++)
        {
            if (i==1)
            {
                string output = new string('.', n / 2) + new string('#', n) + new string('.', n / 2);
                Console.WriteLine(output);
            }
            else if (i>1 && i<n)
            {
                string output = new string('.', n / 2) + new string('#', 1) + new string('.', n-2) + new string('#', 1) + new string('.', n / 2);
                Console.WriteLine(output);
            }
            else if (i==n)
            {
                string output = new string('#', n / 2) + new string('#', 1) + new string('.', n-2) + new string('#', 1) + new string('#', n / 2);
                Console.WriteLine(output);
            }
            else if(i>n && i<2*n-1)
            {
                count++;
                string output = new string('.', count) + new string('#', 1) + new string('.', n + (n / 2) * 2 - 2 * count - 2) + new string('#', 1) + new string('.', count);
                Console.WriteLine(output);
            }
            else if (i == 2 * n-1)
            {
                string output = new string('.', ((n + (n / 2) * 2) - 1) / 2) + new string('#', 1) + new string('.', ((n + (n / 2) * 2) - 1) / 2);
                Console.WriteLine(output);
            }
            
        }
    }
}
