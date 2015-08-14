namespace Export_Finished_Games_as_XML
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    using Diablo_DataBase_First;

    class ExportFinishedGamesXml
    {
        static void Main()
        {
            var context = new DiabloEntities();
            var finishedGames = context.Games
                .Where(g => g.IsFinished == true)
                .OrderBy(g => g.Name)
                .ThenBy(g => g.Duration)
                .Select(g => new
                {
                    name = g.Name,
                    duration = g.Duration,
                    players = g.UsersGames.Select(p => new
                    {
                        userName = p.User.Username,
                        ipAddress = p.User.IpAddress
                    })
                });

            var xml = new XDocument();
            var root = new XElement("games");

            foreach (var game in finishedGames)
            {
                var gameNode = new XElement("game");
                gameNode.SetAttributeValue("name", game.name);
                if (game.duration != null)
                {
                    gameNode.SetAttributeValue("duration", game.duration);
                }

                var xGameRootNode = new XElement("users");

                foreach (var player in game.players)
                {
                    var userNode = new XElement("user");

                    userNode.SetAttributeValue("username", player.userName);
                    userNode.SetAttributeValue("ip-address", player.ipAddress);
                    xGameRootNode.Add(userNode);
                }
                gameNode.Add(xGameRootNode);
                root.Add(gameNode);
            }

            xml.Add(root);
            xml.Save(@"../../../Exports/finished-games.xml");
            //Console.WriteLine(File.ReadAllText(@"../../../finished-games.xml"));
        }
    }
}
