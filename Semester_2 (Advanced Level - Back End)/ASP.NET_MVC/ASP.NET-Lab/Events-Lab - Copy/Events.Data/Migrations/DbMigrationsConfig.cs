namespace Events.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public sealed class DbMigrationsConfig : DbMigrationsConfiguration<Events.Data.EventsDbContext>
    {
        public DbMigrationsConfig()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Events.Data.EventsDbContext context)
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
                var user = new User
                {
                    UserName = "admin", 
                    Email = "admin@admin.com",
                    FullName = "adminFullName"
                };

                manager.Create(user, "password");
                manager.AddToRole(user.Id, "Admin");

            }

            this.CreateSeveralEvents(context);

        }

        private void CreateSeveralEvents(EventsDbContext context)
        {
            context.Events.Add(new Event()
            {
                Title = "Party @ SoftUni",
                StartDateTime = DateTime.Now.Date.AddDays(5).AddHours(21).AddMinutes(30),
                Author = context.Users.First()
            });

            context.Events.Add(new Event()
            {
                Title = "Passed Event <Anonymous>",
                StartDateTime = DateTime.Now.Date.AddDays(-2).AddHours(10).AddMinutes(30),
                Duration =  TimeSpan.FromHours(1.5),
                Comments = new HashSet<Comment>()
                {
                    new Comment(){ Text = "<Anonymous comment>"},
                    new Comment(){Text = "User comment", Author = context.Users.First()}
                }
            });


            context.Events.Add(new Event()
            {
                Title = "MVC Evam",
                StartDateTime = DateTime.Now.Date.AddDays(9).AddHours(21).AddMinutes(35),
                Author = context.Users.First()
            });

            context.Events.Add(new Event()
            {
                Title = "Public Diffence",
                StartDateTime = DateTime.Now.Date.AddDays(8).AddHours(17).AddMinutes(35),
                Author = context.Users.First()
            });

            context.Events.Add(new Event()
            {
                Title = "Last Exam was super",
                StartDateTime = DateTime.Now.Date.AddDays(-8).AddHours(17).AddMinutes(35),
                Author = context.Users.First(),
                Duration = TimeSpan.FromHours(5.5),
                Comments = new HashSet<Comment>()
                {
                    new Comment(){ Text = "<Anonymous comment>"},
                    new Comment(){Text = "Test comment1", Author = context.Users.First()}
                }
            });

            context.Events.Add(new Event()
            {
                Title = "I have to work harder",
                StartDateTime = DateTime.Now.Date.AddDays(-18).AddHours(17).AddMinutes(35),
                Author = context.Users.First()
            });



            context.Events.Add(new Event()
            {
                Title = "Future event <Anonymous>",
                StartDateTime = DateTime.Now.Date.AddDays(5).AddHours(10).AddMinutes(30),
                Duration = TimeSpan.FromHours(5.5),
                Comments = new HashSet<Comment>()
                {
                    new Comment(){ Text = "<Anonymous comment>"},
                    new Comment(){Text = "We will see", Author = context.Users.First()}
                }
            });

        }
    }
}
