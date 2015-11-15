namespace SportSystem.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Model;

    public sealed class Configuration : DbMigrationsConfiguration<SportSystem.Data.SportSystemDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SportSystem.Data.SportSystemDbContext context)
        {
            if (!context.Players.Any())
            {
                this.SeedRoles(context);
                var users = this.SeedUsers(context);
                var teams = this.SeedTeams(context);
                var matches = this.SeedMatches(context, teams);
                this.SeedPlayer(context, teams);
                this.SeedVotes(context, users);
                this.SeedBets(context, matches, users);
                this.SeedComments(context, matches, users);


            }


        }

        private void SeedComments(SportSystemDbContext context, List<Match> matches, List<User> users)
        {
            var match = context.Matches.Find(matches[1].Id);
            match.Comments.Add(new Comment() { MatchId = match.Id, OwnerId = users[0].Id, PostedOn = DateTime.Now, Text = "The best match this summer!" });
            match.Comments.Add(new Comment() { MatchId = match.Id, OwnerId = users[1].Id, PostedOn = DateTime.Now, Text = "The good football this evening." });

            match = context.Matches.Find(matches[1].Id);
            match.Comments.Add(new Comment() { MatchId = match.Id, OwnerId = users[1].Id, PostedOn = DateTime.Now, Text = "Barca!" });

            match = context.Matches.Find(matches[4].Id);
            match.Comments.Add(new Comment() { MatchId = match.Id, OwnerId = users[0].Id, PostedOn = DateTime.Now, Text = "Real forever!" });
            match.Comments.Add(new Comment() { MatchId = match.Id, OwnerId = users[0].Id, PostedOn = DateTime.Now, Text = "Real, real, real" });
            match.Comments.Add(new Comment() { MatchId = match.Id, OwnerId = users[0].Id, PostedOn = DateTime.Now, Text = "Real again :)" });

            match = context.Matches.Find(matches[7].Id);
            match.Comments.Add(new Comment() { MatchId = match.Id, OwnerId = users[1].Id, PostedOn = DateTime.Now, Text = "Chelsea champion!" });

            context.SaveChanges();


        }

        private void SeedBets(SportSystemDbContext context, List<Match> matches, List<User> users)
        {
            var matchesBets = new List<UserMatchBet>()
            {
                new UserMatchBet(){MatchId = matches[0].Id, UserId = users[0].Id, HomeBet = 30m, AwayBet = 0m},
                new UserMatchBet(){MatchId = matches[0].Id, UserId = users[0].Id, HomeBet = 0m, AwayBet = 50m},
                new UserMatchBet(){MatchId = matches[0].Id, UserId = users[0].Id, HomeBet = 0m, AwayBet = 120m},
                new UserMatchBet(){MatchId = matches[2].Id, UserId = users[0].Id, HomeBet = 120m, AwayBet = 0m},
                new UserMatchBet(){MatchId = matches[1].Id, UserId = users[0].Id, HomeBet = 500m, AwayBet = 0m},
                new UserMatchBet(){MatchId = matches[1].Id, UserId = users[1].Id, HomeBet = 50m, AwayBet = 0m},
                new UserMatchBet(){MatchId = matches[1].Id, UserId = users[1].Id, HomeBet = 0m, AwayBet = 20m},
                new UserMatchBet(){MatchId = matches[3].Id, UserId = users[1].Id, HomeBet = 0m, AwayBet = 220m}
            };

            foreach (var bet in matchesBets)
            {
                context.UserMatchBets.Add(bet);
            }

            context.SaveChanges();
        }

        private void SeedVotes(SportSystemDbContext context, List<User> users)
        {
            var votes = new List<Vote>()
            {
                new Vote(){TeamId = 3, UserId = users[1].Id, Value = 1},
                new Vote(){TeamId = 1, UserId = users[1].Id, Value = 1},
                new Vote(){TeamId = 3, UserId = users[0].Id, Value = 1}
            };

            foreach (var vote in votes)
            {
                context.Votes.Add(vote);
            }

            context.SaveChanges();
        }


        private List<Match> SeedMatches(SportSystemDbContext context, List<Team> teams)
        {
            var matches = new List<Match>()
            {
                new Match(){HomeTeam = teams[1], AwayTeam = teams[0], StartDate = new DateTime(2015,6,13)},
                new Match(){HomeTeam = teams[3], AwayTeam = teams[0], StartDate = new DateTime(2015,6,14)},
                new Match(){HomeTeam = teams[2], AwayTeam = teams[4], StartDate = new DateTime(2015,6,15)},
                new Match(){HomeTeam = teams[5], AwayTeam = teams[2], StartDate = new DateTime(2015,6,16)},
                new Match(){HomeTeam = teams[1], AwayTeam = teams[4], StartDate = new DateTime(2015,6,17)},
                new Match(){HomeTeam = teams[0], AwayTeam = teams[5], StartDate = new DateTime(2015,6,18)},
                new Match(){HomeTeam = teams[6], AwayTeam = teams[3], StartDate = new DateTime(2015,6,12)},
                new Match(){HomeTeam = teams[5], AwayTeam = teams[1], StartDate = new DateTime(2015,6,11)},
                new Match(){HomeTeam = teams[5], AwayTeam = teams[4], StartDate = new DateTime(2015,6,10)},
                new Match(){HomeTeam = teams[5], AwayTeam = teams[6], StartDate = new DateTime(2015,6,19)},
                new Match(){HomeTeam = teams[6], AwayTeam = teams[2], StartDate = new DateTime(2015,6,20)},
            };

            foreach (var match in matches)
            {
                context.Matches.Add(match);
            }

            context.SaveChanges();

            return matches;
        }



        private void SeedPlayer(SportSystemDbContext context, List<Team> teams)
        {          
            var players = new List<Player>()
            {
                new Player(){FullName = "Alexis Sanchez", DateOfBirth = new DateTime(1982,1,3), Height = 1.65, TeamId = teams[2].Id},
                new Player(){FullName = "Arjen Robben", DateOfBirth = new DateTime(1982,1,3), Height = 1.65, TeamId = teams[1].Id},
                new Player(){FullName = "Franck Ribery", DateOfBirth = new DateTime(1982,1,3), Height = 1.65, TeamId = teams[0].Id},
                new Player(){FullName = "Wayne Rooney", DateOfBirth = new DateTime(1982,1,3), Height = 1.65, TeamId = teams[0].Id},
                new Player(){FullName = "Lionel Messi", DateOfBirth = new DateTime(1982,1,13), Height = 1.65},
                new Player(){FullName = "Theo Walcott", DateOfBirth = new DateTime(1982,2,17), Height = 1.75},
                new Player(){FullName = "Cristiano Ronaldo", DateOfBirth = new DateTime(1984,3,16), Height = 1.85},
                new Player(){FullName = "Aaron Lennon", DateOfBirth = new DateTime(1985,4,15), Height = 1.95},
                new Player(){FullName = "Gareth Bale", DateOfBirth = new DateTime(1986,5,14), Height = 1.90},
                new Player(){FullName = "Antonio Valencia", DateOfBirth = new DateTime(1987,5,23), Height = 1.82},
                new Player(){FullName = "Robin van Persie", DateOfBirth = new DateTime(1988,6,13), Height = 1.84},
                new Player(){FullName = "Ronaldinho", DateOfBirth = new DateTime(1989,7,30), Height = 1.87}
            };

            foreach (var player in players)
            {
                context.Players.Add(player);
            }

            context.SaveChanges();
        }

        private List<Team> SeedTeams(SportSystemDbContext context)
        {
            var teams = new List<Team>()
            {
                new Team(){Name = "Manchester United F.C.", WebSite = "http://www.manutd.com", DateFounded = new DateTime(1878,6,1), NickName = "The Red Devils"},
                new Team(){Name = "Real Madrid", WebSite = "http://www.realmadrid.com", DateFounded = new DateTime(1902,3,6), NickName = "The Whites"},
                new Team(){Name = "FC Barcelona", WebSite = "http://www.fcbarcelona.com", DateFounded = new DateTime(1899,11,12), NickName = "Barca"},
                new Team(){Name = "Bayern Munich", WebSite = "http://www.fcbayern.de", DateFounded = new DateTime(1900,2,13), NickName = "The Bavarians"},
                new Team(){Name = "Manchester City", WebSite = "http://www.mcfc.com", DateFounded = new DateTime(1880,5,1), NickName = "The Citizens"},
                new Team(){Name = "Chelsea", WebSite = "https://www.chelseafc.com", DateFounded = new DateTime(1905,3,10), NickName = "The Pensioners"},
                new Team(){Name = "Arsenal", WebSite = "http://www.arsenal.com", DateFounded = new DateTime(1886,9,1), NickName = "The Gunners"}
            };

            foreach (var team in teams)
            {
                context.Teams.Add(team);
            }

            context.SaveChanges();
            return teams;
        }

        private void SeedRoles(SportSystemDbContext context)
        {
            // makes an admin role if one doesn't exist
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };

                manager.Create(role);
            }
        }

        private List<User> SeedUsers(SportSystemDbContext context)
        {
            var userStore = new UserStore<User>(context);
            var userManager = new UserManager<User>(userStore);

            var user1 = new User()
            {
                UserName = "alex@usa.net",
                Email = "alex@usa.net"
            };
               
            var user2 = new User()
            {
                UserName = "tanya@gmail.com",
                Email = "tanya@gmail.com"              
            };

            var createUserResult = userManager.Create(user1, "12qw!@QW");
            createUserResult = userManager.Create(user2, "P@ssW0RD!123");
            var users = new List<User>();
            users.Add(user1);
            users.Add(user2);

            return users;
        }
    }
}
