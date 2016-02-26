namespace Bunker_Buster
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Xml;

    public class BunkerBusterMain
    {
        private static int[][] bunkerMatrix;
        public static void Main()
        {
            var inputLine = Console.ReadLine();
            var inputTokens = Regex.Split(inputLine, @"\s+", RegexOptions.IgnoreCase).Select(int.Parse).ToArray();

            var rowsCount = inputTokens[0];
            var collsCount = inputTokens[1];

            bunkerMatrix = new int[rowsCount][];
            FillMatrix(rowsCount);

            while (true)
            {
                inputLine = Console.ReadLine();
                if (inputLine.ToLower().Equals("cease fire!"))
                {
                    break;
                }

                var bombLineTokens =
                    Regex.Split(inputLine, @"\s{1}", RegexOptions.IgnoreCase)
                        .ToArray();

                var row = int.Parse(bombLineTokens[0]);
                var coll = int.Parse(bombLineTokens[1]);
                var power = (int)bombLineTokens[2][0];

                ProcessBombDrop(row, coll, power);
            }

            CalculateResult();

        }

        private static void CalculateResult()
        {
            int cellsDestroyed = bunkerMatrix.Sum(row => row.Count(x => x <= 0));

            Console.WriteLine("Destroyed bunkers: {0}", cellsDestroyed);
            Console.WriteLine("Damage done: {0:F1} %", ((double)cellsDestroyed / (bunkerMatrix.Length * bunkerMatrix.First().Length))*100);
        }

        private static void ProcessBombDrop(int row, int coll, int power)
        {
            bunkerMatrix[row][coll] -= power;
            var halfPower = (int)Math.Ceiling(power/2.0);

            if (coll > 0)
            {
                bunkerMatrix[row][coll - 1] -= halfPower;
            }

            if (coll + 1 < bunkerMatrix[row].Length)
            {
                bunkerMatrix[row][coll + 1] -= halfPower;
            }

            if (row > 0)
            {
                bunkerMatrix[row - 1][coll] -= halfPower;

                if (coll > 0 )
                {
                    bunkerMatrix[row - 1][coll - 1] -= halfPower;
                }

                if (coll + 1 < bunkerMatrix[row].Length)
                {
                    bunkerMatrix[row - 1][coll + 1] -= halfPower;
                }
            }

            if (row + 1 < bunkerMatrix.Length)
            {
                bunkerMatrix[row + 1][coll] -= halfPower;

                if (coll > 0)
                {
                    bunkerMatrix[row + 1][coll - 1] -= halfPower;
                }

                if (coll + 1 < bunkerMatrix[row].Length)
                {
                    bunkerMatrix[row + 1][coll + 1] -= halfPower;
                }
            }
        }

        private static void FillMatrix(int rowsCount)
        {
            for (int i = 0; i < rowsCount; i++)
            {
                var inputLine = Console.ReadLine().Trim();
                var rowArray = Regex.Split(inputLine, @"\s+", RegexOptions.IgnoreCase).Select(int.Parse).ToArray();
                bunkerMatrix[i] = rowArray;
            }
        }
    }
}
