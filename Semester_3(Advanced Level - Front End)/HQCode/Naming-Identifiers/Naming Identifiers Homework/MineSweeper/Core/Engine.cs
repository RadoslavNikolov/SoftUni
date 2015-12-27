namespace Minesweeper.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using global::Minesweeper.Helpers;
    using global::Minesweeper.Intefaces;
    using Models;

    public class Engine : IRunnable
    {
        private const int BoardRows = 5;
        private const int BoardColumns = 10;
        private const int NumOfBombs = 15;
        private const int NumOfClearBoxes = BoardRows*BoardColumns - NumOfBombs;
        private readonly ICollection<IPlayer> players;
        private readonly IReaderWriter readerWriter;

        private char[,] gameBoard;
        private char[,] bombsPositions;
        private string message = "";
        private bool isNewGame = true;
        private bool isDead = false;
        private bool isWinner = false;
        private int turnCounter = 0;

        public Engine(IReaderWriter readerWriter)
        {
            this.readerWriter = readerWriter;
            this.players = new List<IPlayer>();
            this.gameBoard = InitGameObjects.SetGameBoard(BoardRows, BoardColumns);
            this.bombsPositions = InitGameObjects.SetBombsPositions(BoardRows, BoardColumns, NumOfBombs);
        }

        public void Run()
        {
            

            do
            {
                if (this.isNewGame)
                {
                    this.message = "Hajde da igraem na “Mini4KI”. Probvaj si kasmeta da otkriesh poleteta bez mini4ki."
                         + " Komanda 'top' pokazva klasiraneto, 'restart' po4va nova igra, 'exit' izliza i hajde 4ao!";
                    this.readerWriter.Print(this.message);
                    this.readerWriter.PrintGameBoard(this.gameBoard);
                    this.isNewGame = false;
                }

                this.message = "Enter row number and column number ([row] [column])";
                this.readerWriter.Print(this.message);
                var commandLine = this.readerWriter.Read();

                this.message = this.ProcessCommandLine(commandLine);
                this.readerWriter.Print(this.message);

                if (this.isDead)
                {
                    this.readerWriter.PrintGameBoard(this.bombsPositions);

                    this.readerWriter.Print(string.Format(
                        "\nHrrrrrr! Umria gerojski s {0} to4ki. " + "Daj si niknejm: ", this.turnCounter));
                    string playerName = this.readerWriter.Read();
                    this.players.Add(new Player(playerName, this.turnCounter));

                    this.readerWriter.PrintRanking(this.players.OrderByDescending(p => p.Points));

                    this.RestartGame();
                }

                if (this.isWinner)
                {
                    this.readerWriter.Print("\nBRAVOOOS! Otvri 35 kletki bez kapka kryv.");
                    this.readerWriter.PrintGameBoard(this.bombsPositions);

                    this.readerWriter.Print("Daj si imeto, batka: ");
                    string playerName = this.readerWriter.Read();
                    this.players.Add(new Player(playerName, this.turnCounter));

                    this.readerWriter.PrintRanking(this.players.OrderByDescending(p => p.Points));

                    this.RestartGame();
                }


            } while (true);

        }

        private string ProcessCommandLine(string commandLine)
        {
            commandLine = commandLine.Trim();
            var commandTokens = Regex.Split(commandLine, @"\s+");
            var command = "";
            var commadParams = new List<int>();

            if (commandTokens.Length > 1 && commandTokens.Length <= 3)
            {
                command = "turn";
                int row = -1;
                int col = -1;

                int.TryParse(commandTokens[0], out row);
                int.TryParse(commandTokens[1], out col);

                if (row < 0)
                {
                    return "Enter valid integer number for row";
                }

                if (col < 0)
                {
                    return "Enter valid integer number for column";
                }

                if (row >= BoardRows)
                {
                    return "Row number cannot be greater than " + BoardRows;
                }

                if (col >= BoardColumns)
                {
                    return "Col number cannot be greater than " + BoardColumns;
                }

                commadParams.Add(row);
                commadParams.Add(col);
            }

            this.ExecuteCommad(command, commadParams);

            return "";
        }

        private void ExecuteCommad(string command, List<int> commadParams)
        {
            switch (command)
            {
                case "top":
                    this.readerWriter.PrintRanking(this.players);
                    break;
                case "restart":
                    this.RestartGame();               
                    break;
                case "exit":
                    this.readerWriter.Print("4a0, 4a0, 4a0!");
                    Environment.Exit(0);
                    break;
                case "turn":
                    this.ExecuteTurnCommand(commadParams);
                    break;
                default:
                    Console.WriteLine("\nError! Invalid Command!\n");
                    break;
            }
        }

        private void ExecuteTurnCommand(List<int> commadParams)
        {
            var row = commadParams[0];
            var col = commadParams[1];

            if (this.bombsPositions[row, col] != '*')
            {
                if (this.bombsPositions[row, col] == '-')
                {
                    this.MakeTurn(row, col);
                    this.turnCounter++;
                }

                if (NumOfClearBoxes == this.turnCounter)
                {
                    this.isWinner = true;
                }
                else
                {
                    this.readerWriter.PrintGameBoard(this.gameBoard);
                }
            }
            else
            {
                this.isDead = true;
            }
        }

        private void MakeTurn(int currentRow, int currentCol)
        {
            char numOfBombs = this.FindNearByBombs(currentRow, currentCol);
            this.gameBoard[currentRow, currentCol] = numOfBombs;
            this.bombsPositions[currentRow, currentCol] = numOfBombs;
        }

        private char FindNearByBombs(int currentRow, int currentCol)
        {
            int countOfNearByBombs = 0;
            int rows = this.bombsPositions.GetLength(0);
            int cols = this.bombsPositions.GetLength(1);

            if (currentRow - 1 >= 0)
            {
                if (this.bombsPositions[currentRow - 1, currentCol] == '*')
                {
                    countOfNearByBombs++;
                }
            }

            if (currentRow + 1 < rows)
            {
                if (this.bombsPositions[currentRow + 1, currentCol] == '*')
                {
                    countOfNearByBombs++;
                }
            }

            if (currentCol - 1 >= 0)
            {
                if (this.bombsPositions[currentRow, currentCol - 1] == '*')
                {
                    countOfNearByBombs++;
                }
            }

            if (currentCol + 1 < cols)
            {
                if (this.bombsPositions[currentRow, currentCol + 1] == '*')
                {
                    countOfNearByBombs++;
                }
            }

            if ((currentRow - 1 >= 0) && (currentCol - 1 >= 0))
            {
                if (this.bombsPositions[currentRow - 1, currentCol - 1] == '*')
                {
                    countOfNearByBombs++;
                }
            }

            if ((currentRow - 1 >= 0) && (currentCol + 1 < cols))
            {
                if (this.bombsPositions[currentRow - 1, currentCol + 1] == '*')
                {
                    countOfNearByBombs++;
                }
            }

            if ((currentRow + 1 < rows) && (currentCol - 1 >= 0))
            {
                if (this.bombsPositions[currentRow + 1, currentCol - 1] == '*')
                {
                    countOfNearByBombs++;
                }
            }

            if ((currentRow + 1 < rows) && (currentCol + 1 < cols))
            {
                if (this.bombsPositions[currentRow + 1, currentCol + 1] == '*')
                {
                    countOfNearByBombs++;
                }
            }

            return char.Parse(countOfNearByBombs.ToString());
        }

        private void RestartGame()
        {
            this.gameBoard = InitGameObjects.SetGameBoard(BoardRows, BoardColumns);
            this.bombsPositions = InitGameObjects.SetBombsPositions(BoardRows, BoardColumns, NumOfBombs);
            this.readerWriter.PrintGameBoard(this.gameBoard);
            this.isDead = false;
            this.isNewGame = false;
            this.turnCounter = 0;
            this.isNewGame = false;
        }
    }
}