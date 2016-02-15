namespace Matrix_Shuffling
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    class MatrixShufflingProgram
    {
        static void Main()
        {
            Console.Write("Enter n (num of rows): ");
            var n = 0;
            int.TryParse(Console.ReadLine().Trim(), out n);

            Console.Write("Enter m (num of cols): ");
            int m = 0;
            int.TryParse(Console.ReadLine().Trim(), out m);

            string[][] matrix = FillMatrix<string>(n, m);

            while (true)
            {
                var commadInput = Console.ReadLine().Trim();
                string result = ProcessCommand(commadInput, matrix);
                Console.WriteLine(result);
            }

        }

        private static string ProcessCommand(string commadInput, string[][] matrix)
        {
            if (string.IsNullOrWhiteSpace(commadInput) || commadInput.ToLower().Equals("end"))
            {
                Environment.Exit(0);
            }

            var commandTokens = Regex.Split(commadInput, @"\s+", RegexOptions.IgnoreCase);

            if (commandTokens.Length == 5 && commandTokens[0].ToLower().Equals("swap"))
            {
                var p1X = int.Parse(commandTokens[1]);
                var p1Y = int.Parse(commandTokens[2]);
                var p2X = int.Parse(commandTokens[3]);
                var p2Y = int.Parse(commandTokens[4]);

                if (p1X >= matrix.Length || p2X >= matrix.Length || p1Y >= matrix.First().Length || p2Y >= matrix.First().Length)
                {
                    return "Invalid input!";
                }

                var value1 = matrix[p1X][p1Y];
                var value2 = matrix[p2X][p2Y];
                matrix[p1X][p1Y] = value2;
                matrix[p2X][p2Y] = value1;

                return PrintMatrix(matrix, value1, value2);
            }

            return "Invalid input!";
        }

        private static string PrintMatrix(string[][] matrix, string value1, string value2)
        {
            var output = new StringBuilder();

            output.AppendLine(string.Format("(after swapping {0} and {1}):", value1, value2));
            foreach (var row in matrix)
            {
                output.AppendLine(string.Join(" ", row));
            }

            return output.ToString().Trim();
        }

        private static string[][] FillMatrix<T>(int n, int m)
        {
            //We do not need to parse the input, while we only have to change
            string[][] matrix = new string[n][];

            for (int row = 0; row < n; row++)
            {
                var currentRow = new List<string>();

                for (int col = 0; col < m; col++)
                {
                    currentRow.Add(Console.ReadLine().Trim());                 
                }
                matrix[row] = currentRow.ToArray();
            }

            return matrix;
        }
    }
}
