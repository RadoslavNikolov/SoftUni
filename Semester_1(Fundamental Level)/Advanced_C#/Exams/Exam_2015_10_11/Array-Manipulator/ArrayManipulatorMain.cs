namespace Array_Manipulator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Authentication;
    using System.Text.RegularExpressions;
    using System.Threading;

    public static class ArrayManipulatorMain
    {
        private static int[] numArray;

        public static void Main()
        {
            numArray = Regex.Split(Console.ReadLine(), @"\s+", RegexOptions.IgnoreCase)
                .Select(int.Parse).ToArray();

            while (true)
            {
                var commandLine = Console.ReadLine().Trim();

                var commandTokens = Regex.Split(commandLine, @"\s+", RegexOptions.IgnoreCase);
                var command = commandTokens[0];
                var commandParams = commandTokens.Skip(1).ToArray();

                if (command.ToLower().Equals("end"))
                {
                    break;
                }

                ProcessCommand(command, commandParams);
            }

            Console.WriteLine("[{0}]", string.Join(", ", numArray));        
        }

        private static void ProcessCommand(string command, string[] commandParams)
        {
            switch (command.ToLower())
            {
                case "exchange":
                    Exchange(commandParams);
                    break;
                case "max":
                    FindMaxValueIndex(commandParams);
                    break;
                case "min":
                    FindMinValueIndex(commandParams);
                    break;
                case "first":
                    TakeFirstElement(commandParams);
                    break;
                case "last":
                    TakeLastElement(commandParams);
                    break;
                case "end":
                    PrintArray();
                    break;
            }
        }

        private static void TakeLastElement(string[] commandParams)
        {
            int count = int.Parse(commandParams[0]);
            var condition = commandParams[1];
            var resultList = new List<int>();

            if (count > numArray.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            if (condition.ToLower().Equals("odd"))
            {
                resultList = numArray.Where(x => x % 2 != 0).ToList();
            }
            else
            {
                resultList = numArray.Where(x => x % 2 == 0).ToList();
            }

            if (!resultList.Any())
            {
                Console.WriteLine("[]");
                return;
            }

            Console.WriteLine("[{0}]", string.Join(", ", resultList.Skip(Math.Max(0, resultList.Count() - count))));
        }

        private static void TakeFirstElement(string[] commandParams)
        {
            int count = int.Parse(commandParams[0]);
            var condition = commandParams[1];
            var resultList = new List<int>();

            if (count > numArray.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            if (condition.ToLower().Equals("odd"))
            {
                resultList = numArray.Where(x => x%2 != 0).ToList();
            }
            else
            {
                resultList = numArray.Where(x => x%2 == 0).ToList();
            }

            if (!resultList.Any())
            {
                Console.WriteLine("[]");
                return;
            }

            Console.WriteLine("[{0}]", string.Join(", ", resultList.Take(count)));
        }

        private static void PrintArray()
        {
            Console.WriteLine("[{0}]", string.Join(", ", numArray));
        }

        private static void FindMinValueIndex(string[] commandParams)
        {
            if (commandParams[0].ToLower().Equals("odd"))
            {
                if (!numArray.Any(x => x % 2 != 0))
                {
                    Console.WriteLine("No matches");
                    return;
                }

                var minValue = numArray.OrderBy(x => x).FirstOrDefault(x => x % 2 != 0);
                Console.WriteLine(numArray.ToList().LastIndexOf(minValue));
            }
            else
            {
                if (!numArray.Any(x => x % 2 == 0))
                {
                    Console.WriteLine("No matches");
                    return;
                }

                var minValue = numArray.OrderBy(x => x).FirstOrDefault(x => (int?)x % 2 == 0);
                Console.WriteLine(numArray.ToList().LastIndexOf(minValue));
            }
        }

        private static void FindMaxValueIndex(string[] commandParams)
        {
            if (commandParams[0].ToLower().Equals("odd"))
            {
                if (!numArray.Any(x => x % 2 != 0))
                {
                    Console.WriteLine("No matches");
                    return;
                }

                var maxValue = numArray.OrderByDescending(x => x).FirstOrDefault(x => x %2 != 0);
                Console.WriteLine(numArray.ToList().LastIndexOf(maxValue));
            }
            else
            {
                if (!numArray.Any(x => x % 2 == 0))
                {
                    Console.WriteLine("No matches");
                    return;
                }

                var maxValue = numArray.OrderByDescending(x => x).FirstOrDefault(x => x % 2 == 0);
                Console.WriteLine(numArray.ToList().LastIndexOf(maxValue));
            }
        }

        private static void Exchange(string[] commandParams)
        {
            var index = int.Parse(commandParams[0]);
            if (index < 0 || index >= numArray.Length)
            {
                Console.WriteLine("Invalid index"); 
            }

            var tempList = new List<int>();
            tempList.AddRange(numArray.Skip(index + 1));
            tempList.AddRange(numArray.Take(index + 1));
            numArray = tempList.ToArray();
        }     
    }
}
