namespace ConsoleApplication1
{
    using System;

    class MatricesProgram
    {
        static void Main(string[] args)
        {
            var matrix1 = new double[,] { { 1, 3 }, { 5, 7 } };
            var matrix2 = new double[,] { { 4, 2 }, { 1, 5 } };
            var resultMatrix = MultiplyMatrixes(matrix1, matrix2);

            PrintMatrix(resultMatrix);
        }

        private static void PrintMatrix(double[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        static double[,] MultiplyMatrixes(double[,] matrix1, double[,] matrix2)
        {
            if (matrix1.GetLength(1) != matrix2.GetLength(0))
            {
                throw new InvalidOperationException("Number of columns in First Matrix should be equal to Number of rows in Second Matrix.!");
            }
 
            var resultMatrix = new double[matrix1.GetLength(0), matrix2.GetLength(1)];
            for (int row = 0; row < resultMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < resultMatrix.GetLength(1); col++)
                {
                    for (int k = 0; k < matrix1.GetLength(1); k++)
                    {
                        resultMatrix[row, col] += matrix1[row, k] * matrix2[k, col];
                    }
                }
            }

            return resultMatrix;
        }
    }
}