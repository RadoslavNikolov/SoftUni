using System;

class Program
{
    static void Main()
    {
        int startDay = int.Parse(Console.ReadLine());
        int numberOfDays = int.Parse(Console.ReadLine());
        int melons = 0;
        int watermelons = 0;
        for (int i = 1; i <= numberOfDays; i++)
        {
            if (startDay>7)
            {
                startDay = 1;
            }

            switch (startDay)
            {
                case 1: watermelons++; break;
                case 2: melons += 2; break;
                case 3: watermelons++; melons++; break;
                case 4: watermelons += 2; break;
                case 5: watermelons += 2; melons += 2; break;
                case 6: watermelons++; melons += 2; break;
                case 7: break;
                default:
                    break;
            }
            startDay++;
        }

        int sum = watermelons - melons;
        if (sum==0)
        {
            Console.WriteLine("Equal amount: {0}",watermelons);
        }
        else if (sum>0)
        {
            Console.WriteLine("{0} more watermelons", sum);
        }
        else
        {
            Console.WriteLine("{0} more melons",Math.Abs(sum));
        }
    }
}
