using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSystem.Data
{
    using System.Data.Entity;
    using System.Security.AccessControl;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Model;

    public class SportSystemDbContext : IdentityDbContext<User>
    {
        public SportSystemDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static SportSystemDbContext Create()
        {
            return new SportSystemDbContext();
        }

        public virtual IDbSet<Team> Teams { get; set; }

        public virtual IDbSet<Player> Players { get; set; }

        public virtual IDbSet<Match> Matches { get; set; }

        public virtual IDbSet<Comment> Comments { get; set; }

        public virtual IDbSet<UserMatchBet> UserMatchBets { get; set; }

        public virtual IDbSet<Vote> Votes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>()
                .HasRequired(x => x.AwayTeam)
                .WithMany(x => x.AwayMatches)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Match>()
                .HasRequired(x => x.HomeTeam)
                .WithMany(x => x.HomeMatches)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
