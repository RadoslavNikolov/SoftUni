namespace Minesweeper.Helpers
{
    using System;
    using System.Collections.Generic;

    public static class InitGameObjects
    {
        public static char[,] SetBombsPositions(int numOfRows, int numOfColumns, int numOfBombs)
        {
            var gameBoard = SetGameBoard(numOfRows, numOfColumns, '-');
            var randomNumbersList = new HashSet<int>();
            var random = new Random();

            while (randomNumbersList.Count < numOfBombs)
            {
                int randomNumber = random.Next(50);
                randomNumbersList.Add(randomNumber);
            }

            foreach (var number in randomNumbersList)
            {
                int col = number / numOfColumns;
                int row = number % numOfColumns;

                if (row == 0 && number != 0)
                {
                    col--;
                    row = numOfColumns;
                }
                else
                {
                    row++;
                }

                gameBoard[col, row - 1] = '*';
            }

            return gameBoard;
        }


        public static char[,] SetGameBoard(int numOfRows, int numOfColumns, char boardSymbol = '?')
        {
            char[,] gameBoard = new char[numOfRows,numOfColumns];

            for (int row = 0; row < numOfRows; row++)
            {
                for (int col = 0; col < numOfColumns; col++)
                {
                    gameBoard[row, col] = boardSymbol;
                }
            }

            return gameBoard;
        }
    }
}