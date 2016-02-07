using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FootballLeague.Helpers;

namespace FootballLeague.Models
{
    public class Team
    {
        private string name;
        private string nickName;
        private DateTime dateFounded;
        private List<Player> players; 

        public Team(string name, string nickName, DateTime dateFoundated)
        {
            this.Name = name;
            this.NickName = nickName;
            this.DateFounded = dateFoundated;
            this.players = new List<Player>();
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                CustomValidators.ValidateName(value);
                this.name = value;
            }
        }

        public string NickName
        {
            get { return this.nickName; }
            set
            {
                CustomValidators.ValidateName(value);
                this.nickName = value;
            }
        }

        public DateTime DateFounded
        {
            get { return this.dateFounded; }
            set
            {
                CustomValidators.ValidateDate(value);
                this.dateFounded = value;
            }
        }

        public  IEnumerable<Player> Players
        {
            get { return this.players; }
        }

        public void AddPlayer(Player player)
        {
            if (CheckIfPlayerExists(player))
            {
                throw new InvalidOperationException("Player already exists for that team");
            }

            this.players.Add(player);
        }

        public bool CheckIfPlayerExists(Player player)
        {
            return this.Players.Any(p => p.FirstName == player.FirstName &&
                                         p.LastName == player.LastName);
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine("Team name: " + this.Name);
            result.AppendLine("Team nickName: " + this.NickName);
            result.AppendLine("Date founded: " + this.DateFounded.ToString("dd-MM-yyyy"));
            if (players.Any())
            {
                result.AppendLine("Players: " + String.Join(", ", 
                    players.OrderBy(p => p.FirstName)
                    .ThenBy(p => p.LastName)
                    .Select(p => new
                {
                   fullName = p.FirstName +" " +  p.LastName
                }).Select(p => p.fullName).ToArray()));
            }
            return result.ToString();
        }
    }
}