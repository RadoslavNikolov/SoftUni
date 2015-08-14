namespace Mountains_Code_First.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Mountains_Code_First.MountainsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "Mountains_Code_First.MountainsContext";
        }

        protected override void Seed(Mountains_Code_First.MountainsContext context)
        {
            if (context.Countries.Count() == 0)
            {
                //context.Countries.AddOrUpdate(c => c.Code,
                // new Country() { Code = "BG", Name = "Bulgaria"},
                // new Country() { Code = "DE", Name = "Germany" },
                // new Country() { Code = "US", Name = "USA" },
                // new Country() { Code = "IT", Name = "Italy" }
                // );

                var bulgaria = new Country(){Code = "BG", Name = "Bulgaria"};
                context.Countries.Add(bulgaria);
                var germany = new Country() { Code = "DE", Name = "Germany" };
                context.Countries.Add(germany);

                var rila = new Mountain(){Name = "Rila", Countries = {bulgaria}};
                context.Mountains.Add(rila);
                var pirin = new Mountain() { Name = "Pirin", Countries = { bulgaria } };
                context.Mountains.Add(pirin);
                var rhodopes = new Mountain() { Name = "Rhodopes", Countries = { bulgaria } };
                context.Mountains.Add(rhodopes);

                var musala = new Peak(){Name = "Musala", Elevation = 2925, Mountain = rila};
                context.Peaks.Add(musala);
                var malyovitsa = new Peak() { Name = "Malyovitsa", Elevation = 2729, Mountain = rila };
                context.Peaks.Add(malyovitsa);
                var vihren = new Peak() { Name = "Vihren", Elevation = 2914, Mountain = rila };
                context.Peaks.Add(vihren);

                context.SaveChanges();

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
