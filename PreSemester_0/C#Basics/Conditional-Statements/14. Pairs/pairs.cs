using System;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine().Trim();
        string[] strNum = input.Split(' ');
        int value = int.Parse(strNum[0]) + int.Parse(strNum[1]);
        int maxDiff = 0;

        if (strNum.Length == 2)
        {
            Console.WriteLine("Yes, value={0}", value);
        }
        else if (strNum.Length > 2)
        {
            for (int i = 2; i < strNum.Length; i += 2)
            {
                int tempValue = int.Parse(strNum[i]) + int.Parse(strNum[i + 1]);
                int diff = Math.Abs(value - tempValue);
                maxDiff = Math.Max(diff, maxDiff);
                value = tempValue;
            }

            if (maxDiff == 0)
            {
                Console.WriteLine("Yes, value={0}", value);
            }
            else
            {
                Console.WriteLine("No, maxdiff={0}", maxDiff);
            }
        }
    }
}
