namespace Lago_Blocks
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class LegoBlockProgram
    {
        public static void Main()
        {
            Console.Write("Enter n or \"exit\": ");
            string intputLine = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(intputLine) || intputLine.ToLower().Equals("exit"))
            {
                Console.WriteLine("Have a nice day!");
                Environment.Exit(0);
            }

            int n = int.Parse(intputLine);
            int[][] firstArray = new int[n][];
            int[][] secondArray = new int[n][];

            FillInputArrays(firstArray, secondArray, n);

            var totalCells = 0;
            if (!CheckInputArrays(firstArray, secondArray, out totalCells))
            {
                Console.WriteLine("The total number of cells is: {0}", totalCells);
                Environment.Exit(0);
            }

            PrintArrays(firstArray, secondArray);
        }

        private static void PrintArrays(int[][] firstArray, int[][] secondArray)
        {
            for (int i = 0; i < firstArray.Length; i++)
            {
                var concatArray = new int[firstArray[i].Length + secondArray[i].Length];
                firstArray[i].CopyTo(concatArray,0);
                Array.Reverse(secondArray[i]);
                secondArray[i].CopyTo(concatArray, firstArray[i].Length);

                Console.WriteLine("[{0}]", string.Join(", ", concatArray));
            }
        }

        private static bool CheckInputArrays(int[][] firstArray, int[][] secondArray, out int cells)
        {
            bool passed = true;
            cells = 0;

            if (firstArray.Length != secondArray.Length || firstArray.Length == 0)
            {
                passed = false;
            }

            int standartCellsCount = firstArray[0].Length + secondArray[0].Length;

            for (int i = 0; i < firstArray.Length; i++)
            {
                cells += firstArray[i].Length + secondArray[i].Length;

                if (firstArray[i].Length + secondArray[i].Length != standartCellsCount)
                {
                    passed = false;
                }
            }

            return passed;
        }

        private static void FillInputArrays(int[][] firstArray, int[][] secondArray, int dimension)
        {
            for (int i = 1; i <= 2; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    Console.Write("Enter {0} line array for {1} jagged array: ", j + 1, i == 1 ? "first" : "second");
                    var inputLine = Console.ReadLine();

                    if (i == 1)
                    {
                        firstArray[j] = Regex.Split(inputLine, @"\s+", RegexOptions.IgnoreCase).Select(int.Parse).ToArray();
                    }
                    else
                    {
                        secondArray[j] = Regex.Split(inputLine, @"\s+", RegexOptions.IgnoreCase).Select(int.Parse).ToArray();
                    }
                    
                }
            }
        }
    }
}
