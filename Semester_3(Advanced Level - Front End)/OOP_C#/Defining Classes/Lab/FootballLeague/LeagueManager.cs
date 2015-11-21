using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using FootballLeague.Models;

namespace FootballLeague
{
    public class LeagueManager
    {
        public static void HandleInput(string input)
        {
            var inputArgs = input.Split();
            switch (inputArgs[0])
            {
                case "AddTeam" :
                    AddTeam(inputArgs[1], inputArgs[2], DateTime.Parse(inputArgs[3]));
                    break;
                case "AddMatch" :
                    AddMatch(Int32.Parse(inputArgs[1]), inputArgs[2], inputArgs[3], Int32.Parse(inputArgs[4]), Int32.Parse(inputArgs[5]));
                    break;
                case "AddPlayerToTeam":
                    AddPlayerToTeam(inputArgs[1], inputArgs[2], DateTime.Parse(inputArgs[3]), inputArgs[4], inputArgs[5]);
                    break;
                case "ListTeams":
                    ListTeams();
                    break;
                case "ListMatches":
                    ListMatches();
                    break;
                default: break;
            }
        }

        private static void AddPlayerToTeam(string firstName, string lastName, DateTime dateOfBirth, string salary, string playerTeamName)
        {
            var playerSalary = decimal.Parse(salary, CultureInfo.InvariantCulture.NumberFormat);
            var playerTeam = League.Teams.FirstOrDefault(t => t.Name.ToLower().Equals(playerTeamName.ToLower()));
            var player = new Player(firstName, lastName,dateOfBirth, playerSalary, playerTeam);
            if (playerTeam != null)
            {
                playerTeam.AddPlayer(player);
            }
        }

        private static void AddMatch(int matchId, string homeTeamName, string awayTeamName, int homeTeamScore, int awayTeamScore)
        {
            var homeTeam = League.Teams.FirstOrDefault(t => t.Name.ToLower().Equals(homeTeamName.ToLower()));
            var awayTeam = League.Teams.FirstOrDefault(t => t.Name.ToLower().Equals(awayTeamName.ToLower()));
            if (homeTeam != null && awayTeam != null)
            {
                League.AddMatchToLeague(new Match(matchId, homeTeam, awayTeam, homeTeamScore, awayTeamScore));
            }
        }

        private static void AddTeam(string name, string nickName, DateTime dateFounded)
        {
            League.AddTeamToLeague(new Team(name, nickName, dateFounded));
        }

        private static void ListMatches()
        {
            Console.WriteLine(new string('=', Console.BufferWidth / 2));
            var matches = League.Matches as List<Match>;
            if (matches != null && matches.Any())
            {
                matches.ForEach(Console.WriteLine);
            }
            else
            {
                Console.WriteLine("No matches entered in the league");
            }
        }

        private static void ListTeams()
        {
            Console.WriteLine(new string('=', Console.BufferWidth/2));
            var teams = League.Teams as List<Team>;
            if (teams != null && teams.Any())
            {
                teams.ForEach(Console.WriteLine);
            }
            else
            {
                Console.WriteLine("No teams entered in the league");
            }
        }
    }
}