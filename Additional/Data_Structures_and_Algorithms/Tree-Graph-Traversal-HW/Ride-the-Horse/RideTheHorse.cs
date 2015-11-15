namespace Ride_the_Horse
{
    using System;
    using System.Collections.Generic;

    class RideTheHorse
    {
        private static int[,] field;
        private static int numOfRows;
        private static int numOfCols;

        static void Main()
        {
            numOfRows = int.Parse(Console.ReadLine());
            numOfCols = int.Parse(Console.ReadLine());
            field = new int[numOfRows, numOfCols];

            int startX = int.Parse(Console.ReadLine());
            int startY = int.Parse(Console.ReadLine());
            var startCell = new Cell(startX, startY);
            var movementQueue = new Queue<Cell>();

            movementQueue.Enqueue(startCell);

            while (movementQueue.Count > 0)
            {
                var currentCell = movementQueue.Dequeue();

                field[currentCell.X, currentCell.Y] = currentCell.Value;

                TryDirection(currentCell, movementQueue, -2, 1);
                TryDirection(currentCell, movementQueue, -1, 2);
                TryDirection(currentCell, movementQueue, 1, 2);
                TryDirection(currentCell, movementQueue, 2, 1);
                TryDirection(currentCell, movementQueue, 2, -1);
                TryDirection(currentCell, movementQueue, 1, -2);
                TryDirection(currentCell, movementQueue, -1, -2);
                TryDirection(currentCell, movementQueue, -2, -1);
            }

            PrintNeededCol();
        }

        private static void TryDirection(Cell currentCell, Queue<Cell> moveQueue, int x, int y)
        {
            var newX = currentCell.X + x;
            var newY = currentCell.Y + y;

            if (newX >= 0 &&
                newX < numOfRows &&
                newY >= 0 &&
                newY < numOfCols &&
                field[newX, newY] == 0)
            {
                moveQueue.Enqueue(new Cell(newX, newY, currentCell.Value + 1));
            }
        }

        private static void PrintNeededCol()
        {
            Console.WriteLine();

            for (int x = 0; x < numOfRows; x ++)
            {
                Console.WriteLine(field[x, numOfCols/2]);
            }
        }

    }
}
