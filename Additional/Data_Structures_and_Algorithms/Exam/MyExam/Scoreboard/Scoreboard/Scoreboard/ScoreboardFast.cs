namespace Scoreboard
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using Wintellect.PowerCollections;

    public class ScoreBoardSlow
    {
        public static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var center = new MyScoreboardSlow();

            string line = Console.ReadLine();

            while (line != "End")
            {
                if (string.IsNullOrEmpty(line))
                {
                    line = Console.ReadLine();
                    continue;
                }
                string cmdResult = center.ProcessCommend(line);
                Console.WriteLine(cmdResult);
                line = Console.ReadLine();
            }
        }
    }


    public class MyScoreboardSlow
    {
        private const string USER_REGISTERED = "User registered";
        private const string GAME_REGISTERED = "Game registered";
        private const string SCORE_ADDED = "Score added";
        private const string SCORE_NOT_ADDED = "Cannot add score";
        private const string GAME_DELETED = "Game deleted";
        private const string GAME_NOT_DELETED = "Cannot delete game";
        private const string DUBLICATE_USER = "Duplicated user";
        private const string DUBLICATE_GAME = "Duplicated game";
        private const string GAME_NOT_FOUND = "Game not found";
        private const string NO_SCORE = "No score";
        private const string NO_MATCHES = "No matches";
        private const int NUMBER = 10000000;
        

        private readonly Dictionary<string, User> userByUserName = new Dictionary<string, User>();
        private readonly OrderedDictionary<string, Game> gameByGameName = new OrderedDictionary<string, Game>();
        private readonly Dictionary<string,User> userByNameAndPassword = new Dictionary<string, User>(); 
        private readonly Dictionary<string,Game> gameByNameAndPassword = new Dictionary<string, Game>();
        private readonly Dictionary<string, OrderedBag<string>> sortedCollection = new Dictionary<string, OrderedBag<string>>(); 

       


        public string ProcessCommend(string cmdLine)
        {
            int indexOfFirstSpace = cmdLine.IndexOf(' ');
            string command = cmdLine.Substring(0, indexOfFirstSpace);
            string[] cmdParams = cmdLine.Substring(indexOfFirstSpace + 1)
                .Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            switch (command)
            {
                case "RegisterUser":
                    return this.RegisterUser(cmdParams[0], cmdParams[1]);
                case "RegisterGame":
                    return this.RegisterGame(cmdParams[0], cmdParams[1]);
                case "AddScore":
                    return this.AddScore(cmdParams[0], cmdParams[1], cmdParams[2], cmdParams[3], cmdParams[4]);
                case "DeleteGame":
                    return this.DeleteGame(cmdParams[0], cmdParams[1]);
                case "ShowScoreboard":
                    return this.ShowScoreboard(cmdParams[0]);

                case "ListGamesByPrefix":
                    return this.ListGameByPrefix(cmdParams[0]);
                default:
                    return "";
            }

        }

        private string ListGameByPrefix(string namePrefix)
        {
            IEnumerable<string> fullMatchingKeys = fullMatchingKeys = this.gameByGameName.Keys.Where(currentKey => currentKey.StartsWith(namePrefix));

            List<string> returnedValues = new List<string>();

            foreach (string currentKey in fullMatchingKeys)
            {
                returnedValues.Add(gameByGameName[currentKey].GameName);
            }

            if (returnedValues.Count == 0)
            {
                return NO_MATCHES;
            }

            string result = string.Join(", ", returnedValues.Take(10));
            return result;
        }


           

        private string ShowScoreboard(string gameName)
        {
            if (!this.gameByGameName.ContainsKey(gameName))
            {
                return GAME_NOT_FOUND;
            }
            //var games = this.sortedCollection[gameName];

            OrderedBag<string> games;
            this.sortedCollection.TryGetValue(gameName, out games);

            if (games == null)
            {
                return NO_SCORE;
            }
            games = new OrderedBag<string>(games.Take(10));
            return this.PrintProducts(games);
        }

        private string PrintProducts(IEnumerable<string> games)
        {

            var result = new StringBuilder();
            int index = 1;

            foreach (var game in games)
            {
                var KeyValuePair = game.Split(new string[]{"|!|"}, StringSplitOptions.RemoveEmptyEntries);
                var num = (int.Parse(KeyValuePair[0]) - NUMBER)*-1;
                var user = KeyValuePair[1];

                result.AppendLine(string.Format("#{0} {1} {2}", index++, user, num));
            } 
            return result.ToString().Trim();
        }

    


        private string DeleteGame(string gameName, string gamePassword)
        {
            var combineKey = this.CombineKeys(gameName, gamePassword);
            //var game = this.gameByNameAndPassword[combineKey];
            Game game;

            this.gameByNameAndPassword.TryGetValue(combineKey, out game);

            if (game == null)
            {
                return GAME_NOT_DELETED;
            }

            this.sortedCollection.Remove(gameName);
            this.gameByGameName.Remove(gameName);

            return GAME_DELETED;
        }

        private string AddScore(string userName, string userPassword, string gameName, string gamePassword, string score)
        {
            string combineUserKey = this.CombineKeys(userName, userPassword);

            if (!this.userByNameAndPassword.ContainsKey(combineUserKey))
            {
                return SCORE_NOT_ADDED;
            }

            string combineGameKey = this.CombineKeys(gameName, gamePassword);

            if (!this.gameByNameAndPassword.ContainsKey(combineGameKey))
            {
                return SCORE_NOT_ADDED;
            }

            int currentScore;
            int.TryParse(score, out currentScore);

            if (!this.sortedCollection.ContainsKey(gameName))
            {
                this.sortedCollection[gameName] = new OrderedBag<string>();
            }

            //if (!this.sortedCollection[gameName].ContainsKey(currentScore))
            //{
            //    this.sortedCollection[gameName][currentScore].Add(userName);
            //}

            var combineKey = this.CombineKeys((NUMBER - currentScore).ToString(), userName);
            this.sortedCollection[gameName].Add(combineKey);
            
            return SCORE_ADDED;
        }


        private string RegisterUser(string userName, string password)
        {
            if (this.userByUserName.ContainsKey(userName))
            {
                return DUBLICATE_USER;
            }

            var newUser = new User()
            {
                UserName = userName,
                Password = password
            };

            string combineKey = this.CombineKeys(userName, password);

            this.userByUserName[userName] = newUser;
            this.userByNameAndPassword[combineKey] = newUser;

            return USER_REGISTERED;
        }

        private string RegisterGame(string gameName, string password)
        {
            if (this.gameByGameName.ContainsKey(gameName))
            {
                return DUBLICATE_GAME;
            }
            var newGame = new Game()
            {
                GameName = gameName,
                Password = password
            };

            string combineKey = this.CombineKeys(gameName, password);

            this.gameByGameName[gameName] = newGame;
            this.gameByNameAndPassword[combineKey] = newGame;

            return GAME_REGISTERED;
        }

        private string CombineKeys(string name, string password)
        {
            return name + "|!|" + password;
        }

    }

}


public class User
{
    public string UserName { get; set; }

    public string Password { get; set; }
}


public class Game
{
    public string GameName { get; set; }

    public string Password { get; set; }
}

public class ScoreBoard
{
    public User User { get; set; }

    public Game Game { get; set; }

    public int Score { get; set; }

}
