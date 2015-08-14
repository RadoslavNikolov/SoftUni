using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace Import_Leagues_and_Teams_from_XML
{
    using System.Xml.Linq;
    using System.Xml.XPath;
    using Footbal.Model;

    class Program
    {
        static void Main(string[] args)
        {
            var context = new FootballEntities();
            var sourceXml = XDocument.Load(@"../../../leagues-and-teams.xml");
            var leaguesList = sourceXml.XPathSelectElements("/leagues-and-teams/league");
            int count = 0;


            foreach (var xElement in leaguesList)
            {
                Console.WriteLine("Processing league #{0} ...", ++count);
                League league = CreateLeagueIfNotExist(context, xElement);
                var teamlList = xElement.XPathSelectElements("teams/team");
                CreateTeamsIfNotExist(context, teamlList, league);
                Console.WriteLine();
            }

        }

        private static void CreateTeamsIfNotExist(FootballEntities context, IEnumerable<XElement> teamlList, League league)
        {
            foreach (var xTeam in teamlList)
            {
                var teamName = xTeam.Attribute("name").Value;
                var xCountry = xTeam.Attribute("country");
                string countryName = null;
                //Console.WriteLine(teamName);

                if (xCountry != null)
                {
                    countryName = xCountry.Value;
                }

                var team = context.Teams
                    .FirstOrDefault(t => t.TeamName == teamName && t.Country.CountryName == countryName);

                if (team != null)
                {
                    Console.WriteLine("Existing team: {0} ({1})", teamName, countryName);
                }
                else
                {
                    team = new Team()
                    {
                        TeamName = teamName,
                        Country = context.Countries.FirstOrDefault(
                            c => c.CountryName == countryName)
                    };
                    context.Teams.Add(team);
                    context.SaveChanges();
                    Console.WriteLine("Created team: {0} ({1})", teamName, countryName ?? "no country");

                    //Add team to league
                    if (league != null)
                    {
                        if (team.Leagues.Contains(league))
                        {
                            Console.WriteLine("Existing team in league: {0} belongs to {1}",
                                team.TeamName, league.LeagueName);
                        }
                        else
                        {
                            team.Leagues.Add(league);
                            context.SaveChanges();
                            Console.WriteLine("Added team to league: {0} to league {1}",
                                team.TeamName, league.LeagueName);
                        }
                    }
                }
            }
        }

        private static League CreateLeagueIfNotExist(FootballEntities context, XElement xElement)
        {
            League league = null;
            var elementLeagueName = xElement.Element("league-name");
            if (elementLeagueName != null)
            {
                var leagueName = elementLeagueName.Value;
                league = context.Leagues.FirstOrDefault(l => l.LeagueName == leagueName);

                if (league != null)
                {
                    Console.WriteLine("Existing league: {0}", leagueName);
                }
                else
                {
                    league = new League(){ LeagueName = leagueName};
                    context.Leagues.Add(league);
                    context.SaveChanges();
                    Console.WriteLine("Created league: {0}", leagueName);
                }
            }

            return league;
        }
    }
}
