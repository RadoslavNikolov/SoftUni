namespace NewsDB.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Model;

    internal sealed class Configuration : DbMigrationsConfiguration<NewsDB.Data.NewsDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(NewsDB.Data.NewsDBContext context)
        {
            if (!context.News.Any())
            {
                context.News.AddOrUpdate(
                        n => n.Id,
                        new New()
                        {
                            Content = "New planet was found near The Earth!"
                        },
                        new New()
                        {
                            Content = "There was cool music performance this morning!"
                        },
                        new New()
                        {
                            Content = "I have to do my homework!"
                        }); 
            }
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
