using System;

class DiamondTrolls
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int countOuterpart = (n + 1) / 2;

        for (int i = 0; i < n / 2 + 1; i++)
        {
            string middlePart;
            string outerPart = new string('.', countOuterpart);
            if (i == 0)
            {
                middlePart = new string('*', n);
                Console.WriteLine(outerPart + middlePart + outerPart);
                if (countOuterpart > 0)
                {
                    countOuterpart--;
                }
            }
            else if (i < n / 2)
            {
                middlePart = new string('.', ((2 * n + 1) - 3 - 2 * countOuterpart) / 2);
                Console.WriteLine("{0}*{1}*{1}*{0}", outerPart, middlePart);
                if (countOuterpart > 0)
                {
                    countOuterpart--;
                }
            }
            else
            {
                middlePart = new string('.', ((2 * n + 1) - 3 - 2 * countOuterpart) / 2);
                Console.WriteLine("{0}*{1}*{1}*{0}", outerPart, middlePart);
            }
        }
        Console.WriteLine(new string('*', 2 * n + 1));
        for (int i = 0; i < n; i++)
        {
            string middlePart;
            string outerPart = new string('.', countOuterpart);
            if (i != n - 1)
            {
                middlePart = new string('.', ((2 * n + 1) - 3 - (2 * countOuterpart)) / 2);
                Console.WriteLine("{0}*{1}*{1}*{0}", outerPart, middlePart);
                if (countOuterpart < n)
                {
                    countOuterpart++;
                }
            }
            else
            {
                Console.WriteLine(outerPart + "*" + outerPart);
            }
        }
    }
}
