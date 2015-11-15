namespace Template.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Web;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public sealed class Configuration : DbMigrationsConfiguration<Template.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Template.Data.ApplicationDbContext context)
        {
            this.SeedAdmin(context);
            this.SeetTowns(context);
      
        }

        private void SeedAdmin(ApplicationDbContext context)
        {
            // makes an admin role if one doesn't exist
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };

                manager.Create(role);
            }

            // if user doesn't exist, create one and add it to the admin role
            if (!context.Users.Any(u => u.UserName == "admin"))
            {
                var store = new UserStore<User>(context);
                var manager = new UserManager<User>(store);
                var user = new User { UserName = "admin", Email = "admin@admin.com" };

                manager.Create(user, "password");
                manager.AddToRole(user.Id, "Admin");

            }
        }

        private void SeetTowns(ApplicationDbContext context)
        {
            if (!context.Towns.Any())
            {
                string line;
                using (StreamReader file = new StreamReader(HttpContext.Current.Server.MapPath(@"~\") + @"Resources\towns.txt"))
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        var town = new Town
                        {
                            Name = line.Trim()
                        };

                        context.Towns.Add(town);
                    }
                }
            }
        }
    }
}
