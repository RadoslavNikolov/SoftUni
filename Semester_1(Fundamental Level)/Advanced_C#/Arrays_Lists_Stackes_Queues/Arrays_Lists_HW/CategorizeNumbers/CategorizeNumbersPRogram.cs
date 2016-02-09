namespace CategorizeNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CategorizeNumbersPRogram
    {
        public static void Main()
        {
            const string exitCommand = "exit";

            Console.Write("Enter array of floating numbers, separated by space or \"{0}\" for exiting the program: ",
                exitCommand);
            while (true)
            {
                var inputLine = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(inputLine) || inputLine.ToLower().Equals(exitCommand))
                {
                    Environment.Exit(0);
                }

                var inputStringArray = inputLine.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToList();
                var intList = new List<int>();
                var floatList = new List<float>();

                inputStringArray.ForEach(x =>
                {
                    var num = float.Parse(x);
                    if (num%1.0 > 0.0)
                    {
                        floatList.Add(num);
                    }
                    else
                    {
                        intList.Add((int) num);
                    }
                });

                Console.WriteLine("[{0}] -> min: {1}, max: {2}, sum: {3}, avg: {4:F2}", string.Join(", ", floatList), floatList.Min(), floatList.Max(), floatList.Sum(), floatList.Average());
                Console.WriteLine("[{0}] -> min: {1}, max: {2}, sum: {3}, avg: {4:F2}", string.Join(", ", intList), intList.Min(), intList.Max(), intList.Sum(), intList.Average());
                Environment.Exit(0);
            }
        }
    }
}
