using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_InternationalMatchesXML
{
    using System.Globalization;
    using System.IO;
    using System.Xml.Linq;
    using Footbal.Model;

    class InternationsMatchesProgram
    {
        static void Main(string[] args)
        {
            var context = new FootballEntities();
            var intMatches = context.InternationalMatches
                .OrderBy(m => m.MatchDate)
                .ThenBy(m => m.HomeCountry)
                .ThenBy(m => m.AwayCountry)
                .Select(m => new
                {
                    m.HomeCountry,
                    m.AwayCountry,
                    m.HomeCountryCode,
                    m.AwayCountryCode,
                    m.MatchDate,
                    m.HomeGoals,
                    m.AwayGoals,
                    m.League.LeagueName
                }).ToList();


            var xml = new XDocument();
            var root = new XElement("matches");

            foreach (var match in intMatches)
            {
                var matchNode = new XElement("match");
                if (match.MatchDate != null)
                {
                    if (DateTime.Parse(match.MatchDate.ToString()).TimeOfDay.TotalSeconds > 0)
                    {
                        var date = DateTime.Parse(match.MatchDate.ToString());
                        matchNode.SetAttributeValue("date-time", date.ToString("dd-MMM-yyyy hh:mm", CultureInfo.InvariantCulture));
                    }
                    else
                    {
                        var date = DateTime.Parse(match.MatchDate.ToString());
                        matchNode.SetAttributeValue("date", date.ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture));
                    }
                }

                var homeCountryNode = new XElement("home-country");
                homeCountryNode.SetAttributeValue("code", match.HomeCountryCode);
                homeCountryNode.SetValue(match.HomeCountry.CountryName);
                matchNode.Add(homeCountryNode);

                var awayCountryNode = new XElement("away-country");
                awayCountryNode.SetAttributeValue("code", match.AwayCountryCode);
                awayCountryNode.SetValue(match.AwayCountry.CountryName);
                matchNode.Add(awayCountryNode);

                if (match.HomeGoals != null && match.AwayGoals != null)
                {
                    var scoreNode = new XElement("score");
                    scoreNode.SetValue(match.HomeGoals + "-" + match.AwayGoals);
                    matchNode.Add(scoreNode);
                }

                if (match.LeagueName != null)
                {
                    var leagueNode = new XElement("league");
                    leagueNode.SetValue(match.LeagueName);
                    matchNode.Add(leagueNode);
                }

                root.Add(matchNode);
            }

            xml.Add(root);
            xml.Save(@"../../../international-matches.xml");
            Console.WriteLine(File.ReadAllText(@"../../../international-matches.xml"));

        }
    }
}
