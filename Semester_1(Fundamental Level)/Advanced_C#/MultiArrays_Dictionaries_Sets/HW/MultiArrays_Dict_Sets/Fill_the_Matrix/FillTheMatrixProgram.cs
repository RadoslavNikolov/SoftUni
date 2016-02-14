namespace Fill_the_Matrix
{
    using System;
    using System.Linq;

    class FillTheMatrixProgram
    {
        static void Main()
        {
            Console.Write("Enter n(n x n) of the matrix or\"exit\": ");
            var inputLine = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(inputLine) || inputLine.ToLower().Equals("exit"))
            {
                Console.WriteLine("Have a nice day!");
                Environment.Exit(0);
            }

            int n = 0;
            int.TryParse(inputLine, out n);

            int[][] matrix = new int[n][];

            FillMatrix(matrix, "A");
            //FillMatrix(matrix, "B");
            //FillMatrix(matrix, "C");


            PrintMatrix(matrix);
        }

        private static void PrintMatrix(int[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(", ", row));
            }
        }

        private static void FillMatrix(int[][] matrix, string pattern)
        {
            switch (pattern.ToLower())
            {
                case "a":
                    FillMatrixPatternA(matrix);
                    break;
                case "b":
                    FillMatrixPatternB(matrix);
                    break;
                case "c":
                    FillMatrixPatternC(matrix);
                    break;
                default:
                    break;
            }
            
        }

        private static void FillMatrixPatternA(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                var row = Enumerable.Range(0, matrix.Length).Select(j => matrix.Length * i + (j + 1)).ToArray();
                matrix[i] = row;
            }
        }

        private static void FillMatrixPatternC(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                var row = Enumerable.Range(0, matrix.Length)
                    .Select(j => j % 2 == 0 ? (matrix.Length * j + (i + 1)) : (matrix.Length * j + (matrix.Length - i)))
                    .ToArray();
                matrix[i] = row;
            }
        }

        private static void FillMatrixPatternB(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                var row = Enumerable.Range(0, matrix.Length).Select(j => i + 1 + matrix.Length * j).ToArray();
                matrix[i] = row;
            }
        }
    }
}
