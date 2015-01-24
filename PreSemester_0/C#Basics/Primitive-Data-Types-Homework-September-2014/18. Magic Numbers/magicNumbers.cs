using System;
using System.Text.RegularExpressions;

class magicNumbers
{
    static void Main()
    {
        int sum = int.Parse(Console.ReadLine());
        int diff = int.Parse(Console.ReadLine());
        int count = 0;

        for (int i = 111; i <= 777; i++)
        {
            int abc = i;
            int def = diff + abc;
            int ghi = diff + def;
            string number = string.Concat(abc,def,ghi);
            int tempSum = 0;

            foreach (var item in number)
            {
                tempSum += (int)char.GetNumericValue(item);
            }

            if (tempSum==sum && Regex.IsMatch(number,@"^[1-7]+$") && abc<=777 && def<=777 && ghi<=777)
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
