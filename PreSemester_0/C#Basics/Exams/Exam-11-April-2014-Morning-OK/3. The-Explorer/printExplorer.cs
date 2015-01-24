using System;

class printDiamond
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int j = 1;
        for (int i = 0; i < n; i++)
        {

            if (i == 0 || i == n - 1)
            {
                string edgeString = new string('-', n / 2) + new string('*', 1) + new string('-', n / 2);
                Console.WriteLine(edgeString);
            }
            else if (i == n / 2)
            {
                string middleString = new string('*', 1) + new string('-', n - 2) + new string('*', 1);
                Console.WriteLine(middleString);
            }
            else if (i < n / 2)
            {
                string otherString = new string('-', Math.Abs(n / 2 - i)) + new string('*', 1) + new string('-', j) + new string('*', 1) + new string('-', Math.Abs(n / 2 - i));
                Console.WriteLine(otherString);
                j += 2;
            }
            else
            {
                j -= 2;
                string otherString = new string('-', Math.Abs(n / 2 - i)) + new string('*', 1) + new string('-', j) + new string('*', 1) + new string('-', Math.Abs(n / 2 - i));
                Console.WriteLine(otherString);
            }
        }
    }
}
