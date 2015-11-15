namespace Remove_Odd_Occurences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class RemoveOddOccurences
    {
        static void Main(string[] args)
        {
            var line = "";
            var numbersDic = new Dictionary<int, int>();

            while (true)
            {
                numbersDic.Clear();
                Console.Write("Enter sequence of numbers or \"exit\": ");
                line = Console.ReadLine().Trim().ToLower();

                if (line == "")
                {
                    continue;
                }

                if (line == "exit")
                {
                    break;
                }

                var numbers = line.Split(' ').Select(Int32.Parse).ToList();

                foreach (var number in numbers)
                {
                    if (!numbersDic.ContainsKey(number)) numbersDic[number] = 0;

                    numbersDic[number]++;
                }

                foreach (var num in numbersDic)
                {
                    if (num.Value % 2 != 0)
                    {
                        numbers.RemoveAll(n => n == num.Key);
                    }
                }

                numbers.ForEach(Console.WriteLine);
            }
        }
    }
}
