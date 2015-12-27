namespace Minesweeper.IO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using global::Minesweeper.Intefaces;

    public class ConsoleReaderWriter : IReaderWriter
    {
        public string Read()
        {
            var inputLine = Console.ReadLine();

            return inputLine;
        }

        /// <summary>
        /// Print message. There is two available options. Print by Console.Write() or Console.WriteLine().
        /// </summary>
        /// <param name="message">Input message to print</param>
        /// <param name="withoutNewLine">Defines usage of Console.Write() or Console.WriteLine(). By deafult this flag is set to false.
        /// </param>
        public void Print(string message, bool withoutNewLine = false)
        {
            if (withoutNewLine)
            {
                Console.Write(message);
            }
            else
            {
                Console.WriteLine(message);
            }
        }

        public void PrintGameBoard(char[,] gameBoard)
        {
            int rowsCount = gameBoard.GetLength(0);
            int columnsCount = gameBoard.GetLength(1);

            this.Print("\n    0 1 2 3 4 5 6 7 8 9");
            this.Print("   ---------------------");
            for (int row = 0; row < rowsCount; row++)
            {
                this.Print(string.Format("{0} | ", row), true);
                for (int col = 0; col < columnsCount; col++)
                {
                    this.Print(string.Format("{0} ", gameBoard[row, col]), true);
                }

                this.Print("|", true);
                this.Print("");
            }

            this.Print("   ---------------------\n");
        }

        public void PrintRanking(IEnumerable<IPlayer> players)
        {
            this.Print("\nPoints:");
            if (players.Any())
            {
                foreach (var player in players)
                {
                    this.Print(player.ToString());
                }
            }
            else
            {
                this.Print("Empty ranking");
            }       
        }
    }
}