using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballLeague.Models
{
    public static class League
    {
        private static List<Team> teams = new List<Team>();
        private static List<Match> matches = new List<Match>();

        public static IEnumerable<Team> Teams
        {
            get { return teams; }
        }

        public static IEnumerable<Match> Matches
        {
            get { return matches; }
        }

        public static void AddTeamToLeague(Team team)
        {
            if (CheckIfTeamExists(team))
            {
                throw new InvalidOperationException("Team already exists for this league");
            }
            teams.Add(team);
        }

        public static void AddMatchToLeague(Match match)
        {
            if (CheckIfMatchExists(match))
            {
                throw new InvalidOperationException("Match already exists for this league");
            }
            matches.Add(match);
        }

        public static bool CheckIfTeamExists(Team team)
        {
            return teams.Any(t => t.Name == team.Name);
        }

        public static bool CheckIfMatchExists(Match match)
        {
            return matches.Any(m => m.Id == match.Id);
        }
    }
}