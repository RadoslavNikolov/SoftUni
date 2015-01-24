using System;
using System.Text.RegularExpressions;

class magicNumbers
{
    static void Main()
    {
        int sum = int.Parse(Console.ReadLine());
        int diff = int.Parse(Console.ReadLine());
        int count = 0;

        for (int i = 555; i <= 999; i++)
        {
            int abc = i;
            int def = diff + abc;
            int ghi = diff + def;
            string number = string.Concat(abc, def, ghi);
            int tempSum = 0;

            foreach (var item in number)
            {
                tempSum += (int)char.GetNumericValue(item);
            }

            if (tempSum == sum && Regex.IsMatch(number, @"^[5-9]+$") && abc <= 999 && def <= 999 && ghi <= 999)
            {
                Console.WriteLine(number);
                count++;
            }
        }

        if (count == 0)
        {
            Console.WriteLine("No");
        }
    }
}
