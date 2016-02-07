namespace WalkInMatrix
{
    using System;

    public class RotatingMatrix
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter a positive number: ");
            string input = Console.ReadLine();
            int n = 0;

            while (!int.TryParse(input, out n))
            {
                input = Console.ReadLine();
            }

            int[,] matrix = GenerateRotationWalkMatrix(n);

            PrintOnConsole(matrix);
        }

        public static int[,] GenerateRotationWalkMatrix(int n)
        {
            int[,] matrix = new int[n, n];
            int nextNumber = 1;
            int currectRow = 0;
            int currectCol = 0;
            int directionRow = 1;
            int directionCol = 1;

            while (true)
            {
                matrix[currectRow, currectCol] = nextNumber;

                if (!CheckForAvaibleCell(matrix, currectRow, currectCol))
                {
                    FindCell(matrix, out currectRow, out currectCol);

                    nextNumber++;

                    if (currectRow != 0 && currectCol != 0)
                    {
                        directionRow = 1;
                        directionCol = 1;

                        while (true)
                        {
                            matrix[currectRow, currectCol] = nextNumber;

                            if (!CheckForAvaibleCell(matrix, currectRow, currectCol))
                            {
                                break;
                            }

                            while (NextDistinationIsntAvaible(matrix, currectRow, currectCol, directionRow, directionCol))
                            {
                                RotateUntilFindAvaibleDestination(ref directionRow, ref directionCol);
                            }

                            currectRow += directionRow;
                            currectCol += directionCol;
                            nextNumber++;
                        }
                    }

                    break;
                }

                while (NextDistinationIsntAvaible(matrix, currectRow, currectCol, directionRow, directionCol))
                {
                    RotateUntilFindAvaibleDestination(ref directionRow, ref directionCol);
                }

                currectRow += directionRow;
                currectCol += directionCol;
                nextNumber++;
            }

            return matrix;
        }

        private static bool NextDistinationIsntAvaible(int[,] matrix, int currectRow, int currectCol, int directionRow, int directionCol)
        {
            return CheckForInvalidRow(matrix, currectRow, directionRow) ||
                   CheckForInvalidCol(matrix, currectCol, directionCol) ||
                   CheckIfNextCellIsNotAvaible(matrix, currectRow, currectCol, directionRow, directionCol);
        }

        private static bool CheckIfNextCellIsNotAvaible(int[,] matrix, int currectRow, int currectCol, int directionRow, int directionCol)
        {
            return matrix[currectRow + directionRow, currectCol + directionCol] != 0;
        }

        private static bool CheckForInvalidRow(int[,] matrix, int currectRow, int directionRow)
        {
            return currectRow + directionRow >= matrix.GetLength(0) || currectRow + directionRow < 0;
        }

        private static bool CheckForInvalidCol(int[,] matrix, int currectCol, int directionCol)
        {
            return currectCol + directionCol >= matrix.GetLength(1) || currectCol + directionCol < 0;
        }

        private static bool CheckForAvaibleCell(int[,] arr, int row, int col)
        {
            int[] dirRow = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] dirCol = { 1, 0, -1, -1, -1, 0, 1, 1 };

            for (int i = 0; i < dirRow.Length; i++)
            {
                if (row + dirRow[i] >= arr.GetLength(0) || row + dirRow[i] < 0)
                {
                    dirRow[i] = 0;
                }

                if (col + dirCol[i] >= arr.GetLength(0) || col + dirCol[i] < 0)
                {
                    dirCol[i] = 0;
                }
            }

            for (int i = 0; i < dirRow.Length; i++)
            {
                if (arr[row + dirRow[i], col + dirCol[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        private static void RotateUntilFindAvaibleDestination(ref int dx, ref int dy)
        {
            int[] dirRow = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] dirCol = { 1, 0, -1, -1, -1, 0, 1, 1 };
            int cd = 0;

            for (int count = 0; count < dirRow.Length; count++)
            {
                if (dirRow[count] == dx && dirCol[count] == dy)
                {
                    cd = count;
                    break;
                }
            }

            if (cd == 7)
            {
                dx = dirRow[0];
                dy = dirCol[0];
                return;
            }

            dx = dirRow[cd + 1];
            dy = dirCol[cd + 1];
        }

        private static void FindCell(int[,] arr, out int row, out int col)
        {
            row = 0;
            col = 0;

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] == 0)
                    {
                        row = i;
                        col = j;
                        return;
                    }
                }
            }
        }

        private static void PrintOnConsole(int[,] matix)
        {
            for (int row = 0; row < matix.GetLength(0); row++)
            {
                for (int col = 0; col < matix.GetLength(1); col++)
                {
                    Console.Write("{0,4}", matix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}