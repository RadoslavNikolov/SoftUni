namespace Target_Practice
{
    using System;
    using System.Text.RegularExpressions;

    public class TargetPracticeMain
    {
        private static char[][] stairsMatrix;
        public static void Main()
        {
            var inputLine = Console.ReadLine().Trim();
            var tokens = Regex.Split(inputLine, @"\s+");
            var rowsCount = int.Parse(tokens[0]);
            var collsCount = int.Parse(tokens[1]);

            var snakeStr = Console.ReadLine();
            stairsMatrix = new char[rowsCount][];

            FillMatrix(rowsCount, collsCount, snakeStr);

            inputLine = Console.ReadLine().Trim();
            tokens = Regex.Split(inputLine, @"\s+");
            var impactRow = int.Parse(tokens[0]);
            var impactColl = int.Parse(tokens[1]);
            var radius = int.Parse(tokens[2]);

            Shoot(impactRow, impactColl, radius);
            MatrixGravity();
            Printmatrix();
        }

        private static void Printmatrix()
        {
            foreach (char[] row in stairsMatrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static void Shoot(int impactRow, int impactCol, int radius)
        {
            for (int row = 0; row < stairsMatrix.Length; row++)
            {
                for (int col = 0; col < stairsMatrix[row].Length; col++)
                {
                    if (InsideCircle(row, col, impactRow, impactCol, radius))
                    {
                        stairsMatrix[row][col] = ' ';
                    }
                }
            }
        }

        private static bool InsideCircle(int currentRow, int currentCol, int impactRow, int impactCol, int radius)
        {
            int deltaRow = currentRow - impactRow;
            int deltaCol = currentCol - impactCol;
            bool isInRadius = deltaRow * deltaRow + deltaCol * deltaCol <= radius * radius;

            return isInRadius;
        }

        private static void MatrixGravity()
        {
            var isMooving = true;

            while (isMooving)
            {
                isMooving = false;
                for (int row = stairsMatrix.Length - 2; row >= 0; row--)
                {
                    for (int col = 0; col < stairsMatrix[row].Length; col++)
                    {
                        if (stairsMatrix[row][col] != ' ')
                        {
                            //Move down char
                            for (int newRow = row + 1; newRow < stairsMatrix.Length; newRow++)
                            {
                                if (stairsMatrix[newRow][col] == ' ')
                                {
                                    //Switch chars
                                    stairsMatrix[newRow][col] = stairsMatrix[row][col];
                                    stairsMatrix[row][col] = ' ';
                                    isMooving = true;
                                }
                            }
                        }
                    }
                }
            }
        }

        private static void FillMatrix(int rowsCount, int collsCount, string snakeStr)
        {
            var charIndex = 0;
            bool toLeft = true;

            for (int row = rowsCount - 1; row >= 0; row--)
            {
                stairsMatrix[row] = new char[collsCount];
                if (toLeft)
                {
                    for (int coll = collsCount - 1; coll >= 0; coll--)
                    {
                        stairsMatrix[row][coll] = snakeStr[(charIndex++) % snakeStr.Length];
                    }
                }
                else
                {
                    for (int coll = 0; coll < collsCount; coll++)
                    {
                        stairsMatrix[row][coll] = snakeStr[(charIndex++) % snakeStr.Length];
                    }
                }

                toLeft = !toLeft;
            }
        }
    }
}
