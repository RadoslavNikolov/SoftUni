using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battelship.Game
{
    class Program
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine();
            while (line.ToLower() != "exit")
            {
                var splitedCommandLine = line.Trim().Split(' ');
                var command = splitedCommandLine[1];
                switch (command)
                {
                    case "register":
                        GameFactory.Register(splitedCommandLine);
                        break;
                    case "login":
                        GameFactory.Login(splitedCommandLine);
                        break;
                    case "create-game":
                        GameFactory.CreateGame();
                        break;
                    case "join-game":
                        GameFactory.JoinGame(splitedCommandLine);
                        break;
                    case "play":
                        GameFactory.PlayGame(splitedCommandLine);
                        break;
                    default:
                        Console.WriteLine("Invalid command " + command);
                        break;
                }

                line = Console.ReadLine();
            }

        }
    }
}
