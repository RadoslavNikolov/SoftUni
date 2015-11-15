namespace Battleships.Data
{
    using System.Data.Entity;

    using Battleships.Data.Migrations;

    using Battleships.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("name=BattelshipContext", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public virtual IDbSet<Game> Games { get; set; }

        public virtual IDbSet<Ship> Ships { get; set; }
    }
}
