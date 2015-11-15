﻿namespace SportSystem.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Team
    {
        private ICollection<Player> players;
        private ICollection<Vote> votes;
        private ICollection<Match> homeMatches;
        private ICollection<Match> awayMatches;
        
        public Team()
        {
            this.players = new HashSet<Player>();
            this.votes = new HashSet<Vote>();
            this.homeMatches = new HashSet<Match>();
            this.awayMatches = new HashSet<Match>();
        }

        [Key]
        public int Id { get; set; } 

        [Required]
        public string Name { get; set; }

        public string NickName { get; set; }

        public string WebSite { get; set; }

        public DateTime? DateFounded { get; set; }

        public virtual ICollection<Player> Players
        {
            get { return this.players; }
            set { this.players = value; }
        }

        public virtual ICollection<Vote> Votes
        {
            get { return this.votes; }
            set { this.votes = value; }
        }

        public virtual ICollection<Match> HomeMatches
        {
            get { return this.homeMatches; }
            set { this.homeMatches = value; }
        }

        public virtual ICollection<Match> AwayMatches
        {
            get { return this.awayMatches; }
            set { this.awayMatches = value; }
        }
    }
}