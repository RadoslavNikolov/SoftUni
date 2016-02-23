namespace Plus_Remove
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PlusRemoveMain
    {
        private static readonly IList<string> matrix = new List<string>();  

        public static void Main()
        {
            FillMatrix();

            IList<string> resultmatrix = new List<string>();
            foreach (var row in matrix)
            {
                var clonedRow = (string) row.Clone();
                resultmatrix.Add(clonedRow);
            }

            resultmatrix = ProcessMatrix(resultmatrix);
            PrintMatrix(resultmatrix);
        }

        private static void PrintMatrix(IList<string> matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(row.Replace(" ", ""));
            }
        }

        private static IList<string> ProcessMatrix(IList<string> resultmatrix)
        {
            for (int row = 0; row < matrix.Count-2; row++)
            {
                for (int col = 1; col < matrix[row].Length; col++)
                {
                    if (PlusExists(row, col))
                    {
                        MarkPlus(resultmatrix, row, col);
                    }
                }
            }

            return resultmatrix;
        }

        private static void MarkPlus(IList<string> resultmatrix, int row, int col)
        {
            var currRow = resultmatrix[row].ToCharArray();
            currRow[col] = ' ';
            resultmatrix[row] = string.Join("", currRow);

            currRow = resultmatrix[row + 1].ToCharArray();
            currRow[col - 1] = ' ';
            currRow[col] = ' ';
            currRow[col + 1] = ' ';
            resultmatrix[row + 1] = string.Join("", currRow);

            currRow = resultmatrix[row + 2].ToCharArray();
            currRow[col] = ' ';
            resultmatrix[row + 2] = string.Join("", currRow);
        }


        private static bool PlusExists(int row, int col)
        {
            if ( matrix[row + 1].Length <= col + 1)
            {
                return false;
            }

            if (matrix[row + 2].Length <= col)
            {
                return false;
            }

            var symbol = char.ToLower(matrix[row][col]);

            return char.ToLower(matrix[row + 1][col - 1]) == symbol &&
                   char.ToLower(matrix[row + 1][col]) == symbol &&
                   char.ToLower(matrix[row + 1][col + 1]) == symbol &&
                   char.ToLower(matrix[row + 2][col]) == symbol;
        }


        private static void FillMatrix()
        {
            while (true)
            {
                var inputLine = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(inputLine) || inputLine.ToLower().Equals("end"))
                {
                    break;
                }

                matrix.Add(inputLine);
            }
        }
    }
}
