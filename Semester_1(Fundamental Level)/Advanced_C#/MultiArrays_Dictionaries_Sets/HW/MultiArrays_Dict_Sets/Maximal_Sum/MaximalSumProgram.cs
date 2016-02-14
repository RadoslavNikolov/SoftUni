using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximal_Sum
{
    using System.Runtime.InteropServices;
    using System.Text.RegularExpressions;

    static class MaximalSumProgram
    {
        const int SquareSize = 3;

        static void Main()
        {
            Console.Write("Enter dimansion(n x m) of the matrix or\"exit\": ");
            var inputLine = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(inputLine) || inputLine.ToLower().Equals("exit"))
            {
                Console.WriteLine("Have a nice day!");
                Environment.Exit(0);
            }

            var matrix = FillMatrix(inputLine);
            CheckForMaxSum(matrix);
        }

        private static void CheckForMaxSum(int[][] matrix)
        {
            var maxMatrix = new int[SquareSize][];
            var maxSum = int.MinValue;

            for (int row = 0; row <= matrix.Length - SquareSize; row++)
            {
                for (int col = 0; col <= matrix[row].Length - SquareSize; col++)
                {
                    var currentMatrix = new int[SquareSize][];

                    for (int innerMatrixRow = 0; innerMatrixRow < SquareSize; innerMatrixRow++)
                    {
                        var currentRow = matrix[row + innerMatrixRow].Skip(col).Take(SquareSize).ToArray();
                        currentMatrix[innerMatrixRow] = currentRow;
                    }

                    var currentSum = currentMatrix.Sum(r => r.Sum());
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        maxMatrix = currentMatrix;
                    }
                }           
            }

            PrintMatrix(maxMatrix, maxSum);
        }

        private static void PrintMatrix(int[][] maxMatrix, int maxSum)
        {
            Console.WriteLine("Sum = {0}", maxSum);

            maxMatrix.Select(row => string.Join("  ", row)).ToList().ForEach(Console.WriteLine);

            //// OR
            //foreach (var row in maxMatrix)
            //{
            //    Console.WriteLine(string.Join("  ", row));
            //}
        }

        private static int[][] FillMatrix(string inputLine)
        {
            var inputTokens = Regex.Split(inputLine, @"\s+", RegexOptions.IgnoreCase).Select(int.Parse).ToArray();
            if (inputTokens[0] < SquareSize || inputTokens[1] < SquareSize)
            {
                throw new ArgumentException("Invalid matrix size. Matrix is smaller than desired square.");
            }
            int[][] matrix = new int[inputTokens[0]][];

            for (int i = 0; i < inputTokens[0]; i++)
            {
                var matrixInputLine = Console.ReadLine().Trim();
                var matrixLine =
                    Regex.Split(matrixInputLine, @"\s+", RegexOptions.IgnoreCase).Select(int.Parse).ToArray();
                if (matrixLine.Length != inputTokens[1])
                {
                    throw new ArgumentException(
                        string.Format("Invalid matrix input line. Numbers count does not match to {0}", inputTokens[1]));
                }

                matrix[i] = matrixLine;
            }

            return matrix;
        }
    }
}
