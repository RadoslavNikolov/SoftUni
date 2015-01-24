using System;

class Eggcelent
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int countOuterDots = n + 1;
        int count = 0;

        for (int i = 0; i < n - 1; i++)
        {
            string outerPart = "";
            string middlePart = "";
            if (i == 0)
            {
                outerPart = new string('.', countOuterDots);
                middlePart = new string('*', (3 * n + 1) - 2 * countOuterDots);
                Console.WriteLine(outerPart + middlePart + outerPart);
                if (countOuterDots > 1)
                {
                    countOuterDots -= 2;
                }
                else
                {
                    count++;
                }


            }
            else
            {
                outerPart = new string('.', countOuterDots);
                middlePart = new string('.', (3 * n - 1) - 2 * countOuterDots);
                Console.WriteLine(outerPart + "*" + middlePart + "*" + outerPart);
                if (countOuterDots > 1)
                {
                    countOuterDots -= 2;
                }
                else
                {
                    count++;
                }
            }
        }
        for (int i = 0; i < 2 * n - 2 * (n - 1); i++)
        {
            string outerPart = "";
            string middlePart = "";
            if (i % 2 == 0)
            {
                outerPart = new string('.', countOuterDots);
                for (int j = 0; j < 3 * n - 1 - 2 * countOuterDots; j++)
                {
                    if (j % 2 == 0)
                    {
                        middlePart += "@";
                    }
                    else
                    {
                        middlePart += ".";
                    }
                }
                Console.WriteLine(outerPart + "*" + middlePart + "*" + outerPart);
            }
            else
            {
                outerPart = new string('.', countOuterDots);
                for (int j = 0; j < 3 * n - 1 - 2 * countOuterDots; j++)
                {
                    if (j % 2 == 0)
                    {
                        middlePart += ".";
                    }
                    else
                    {
                        middlePart += "@";
                    }
                }
                Console.WriteLine(outerPart + "*" + middlePart + "*" + outerPart);
            }
        }

        for (int i = 0; i < n - 1; i++)
        {
            string outerPart = "";
            string middlePart = "";
            if (i == n - 2)
            {
                if (count == 0)
                {
                    countOuterDots += 2;
                }
                else
                {
                    count--;
                }
                outerPart = new string('.', countOuterDots);
                middlePart = new string('*', (3 * n + 1) - 2 * countOuterDots);
                Console.WriteLine(outerPart + middlePart + outerPart);
            }
            else
            {
                if (count == 0)
                {
                    countOuterDots += 2;
                }
                else
                {
                    count--;
                }
                outerPart = new string('.', countOuterDots);
                middlePart = new string('.', (3 * n - 1) - 2 * countOuterDots);
                Console.WriteLine(outerPart + "*" + middlePart + "*" + outerPart);
            }
        }
    }
}
