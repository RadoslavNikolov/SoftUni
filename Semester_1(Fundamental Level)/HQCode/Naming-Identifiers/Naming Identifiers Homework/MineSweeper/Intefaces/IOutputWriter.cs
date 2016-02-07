namespace Minesweeper.Intefaces
{
    using System.Collections.Generic;

    public interface IOutputWriter
    {
        void Print(string message, bool withoutNewLine = false);

        void PrintGameBoard(char[,] gameBoard);

        void PrintRanking(IEnumerable<IPlayer> players);
    }
}