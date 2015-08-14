using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_LeaguesJSON
{
    using System.IO;
    using Footbal.Model;
    using Newtonsoft.Json;

    class LeaguesAndTeamsJSON
    {
        static void Main(string[] args)
        {
            var context = new FootballEntities();

            var leaguesTeams = context.Leagues
                .OrderBy(l => l.LeagueName)
                .Select(l => new
                {
                    leagueName = l.LeagueName,
                    teams = l.Teams.OrderBy(t => t.TeamName).Select(
                        t => t.TeamName).ToList()
                }).ToList();

            var beautifulJson = JsonConvert.SerializeObject(leaguesTeams, (Newtonsoft.Json.Formatting)Formatting.Indented);
            File.WriteAllText(@"../../../leagues-and-teams.json", beautifulJson);
            //Console.WriteLine(beautifulJson);
        }
    }
}
