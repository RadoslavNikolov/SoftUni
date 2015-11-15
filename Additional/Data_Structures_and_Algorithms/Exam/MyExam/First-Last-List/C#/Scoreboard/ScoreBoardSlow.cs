//namespace Scoreboard
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Globalization;
//    using System.Linq;
//    using System.Text;
//    using System.Threading;

//    public class ScoreBoardSlow
//    {
//        public static void Main(string[] args)
//        {
//            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

//            var center = new MyScoreboardSlow();

//            string line = Console.ReadLine();

//            while (line != "End")
//            {
//                if (string.IsNullOrEmpty(line))
//                {
//                    line = Console.ReadLine();
//                    continue;
//                }
//                string cmdResult = center.ProcessCommend(line);
//                Console.WriteLine(cmdResult);
//                line = Console.ReadLine();
//            }
//        }
//    }


//    public class MyScoreboardSlow
//    {
//       private const string USER_REGISTERED = "User registered";
//        private const string GAME_REGISTERED = "Game registered";
//        private const string SCORE_ADDED = "Score added";
//        private const string SCORE_NOT_ADDED = "Cannot add score";
//        private const string GAME_DELETED = "Game deleted";
//        private const string GAME_NOT_DELETED = "Cannot delete game";
//        private const string DUBLICATE_USER = "Duplicated user";
//        private const string DUBLICATE_GAME = "Duplicated game";
//        private const string GAME_NOT_FOUND = "Game not found";
//        private const string NO_SCORE = "No score";
//        private const string NO_MATCHES = "No matches";

//        private readonly  List<User> users = new List<User>();
//        private readonly List<Game> games = new List<Game>(); 
//        private readonly List<ScoreBoard> scores = new List<ScoreBoard>(); 
 

//        public string ProcessCommend(string cmdLine)
//        {
//            int indexOfFirstSpace = cmdLine.IndexOf(' ');
//            string command = cmdLine.Substring(0, indexOfFirstSpace);
//            string[] cmdParams = cmdLine.Substring(indexOfFirstSpace + 1)
//                .Trim().Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);

//            switch (command)
//            {
//                case "RegisterUser":
//                    return this.RegisterUser(cmdParams[0], cmdParams[1]);
//                case "RegisterGame":
//                    return this.RegisterGame(cmdParams[0], cmdParams[1]);
//                case "AddScore":
//                    return this.AddScore(cmdParams[0], cmdParams[1], cmdParams[2], cmdParams[3], cmdParams[4]);
//                case "DeleteGame" :
//                    return this.DeleteGame(cmdParams[0], cmdParams[1]);
//                case "ShowScoreboard":
//                    return this.ShowScoreboard(cmdParams[0]);

//                case "ListGamesByPrefix":
//                    return this.ListGameByPrefix(cmdParams[0]);
//                default:
//                    return "";
//            }

//        }

//        private string ListGameByPrefix(string namePrefix)
//        {
//            var games = this.games.Where(g => g.GameName.StartsWith(namePrefix))
//                .OrderBy(g => g.GameName)
//                .Take(10)
//                .Select(g => g.GameName).ToList();

//            if (games.Count == 0)
//            {
//                return NO_MATCHES;
//            }

//            string result = string.Join(", ", games);
//            return result;
//        }

//        private string ShowScoreboard(string gameName)
//        {
//            var game = this.games.FirstOrDefault(g => g.GameName == gameName);

//            if (game == null)
//            {
//                return GAME_NOT_FOUND;
//            }

//            var scoresToPrint = this.scores.Where(s => s.Game.GameName == gameName)
//                .OrderByDescending(g => g.Score)
//                .ThenBy(g => g.User.UserName)
//                .Take(10);

//            return this.PrintProducts(scoresToPrint);

//        }

//        private string PrintProducts(IEnumerable<ScoreBoard> scoresToPrint)
//        {
//            if (!scoresToPrint.Any())
//            {
//                return NO_SCORE;
//            }

//            var result = new StringBuilder();

//            int index = 1;
//            foreach (var item in scoresToPrint)
//            {
//                result.AppendLine(string.Format("#{0} {1} {2}", index++, item.User.UserName, item.Score));
//            }

//            return result.ToString().Trim();
//        }

//        private string DeleteGame(string gameName, string gamePassword)
//        {
//            var game = this.games.FirstOrDefault(g => g.GameName == gameName && g.Password == gamePassword);

//            if (game == null)
//            {
//                return GAME_NOT_DELETED;
//            }

//            this.scores.RemoveAll(s => s.Game.GameName == gameName);
//            this.games.Remove(game);

//            return GAME_DELETED;
//        }

//        private string AddScore(string userName, string userPassword, string gameName, string gamePassword, string score)
//        {
//            var user = this.users.FirstOrDefault(u => u.UserName == userName && u.Password == userPassword);

//            if (user == null)
//            {
//                return SCORE_NOT_ADDED;
//            }

//            var game = this.games.FirstOrDefault(g => g.GameName == gameName && g.Password == gamePassword);

//            if (game == null)
//            {
//                return SCORE_NOT_ADDED;
//            }

//            int currentScore;
//            int.TryParse(score, out currentScore);

//            var newScoreboard = new ScoreBoard()
//            {
//                Game = game,
//                User = user,
//                Score = currentScore
//            };

//            this.scores.Add(newScoreboard);

//            return SCORE_ADDED;
//        }


//        private string RegisterUser(string userName, string password)
//        {
//            if (users.Any(u => u.UserName == userName))
//            {
//                return DUBLICATE_USER;
//            }
//            var newUser = new User()
//            {
//                UserName = userName,
//                Password = password
//            };

//            this.users.Add(newUser);

//            return USER_REGISTERED;
//        }

//        private string RegisterGame(string gameName, string password)
//        {
//            if (games.Any(g => g.GameName == gameName))
//            {
//                return DUBLICATE_GAME;
//            }
//            var newGame = new Game()
//            {
//                GameName = gameName,
//                Password = password
//            };

//            this.games.Add(newGame);

//            return GAME_REGISTERED;
//        }

//        }
       
//    }


//    public class User
//    {
//        public string UserName { get; set; }

//        public string Password { get; set; }
//    }


//    public class Game
//    {
//        public string GameName { get; set; }

//        public string Password { get; set; }
//    }

//    public class ScoreBoard
//    {
//        public User User { get; set; }

//        public Game Game { get; set; }

//        public int Score { get; set; }

//    }
