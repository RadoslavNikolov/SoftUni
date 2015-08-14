namespace Mountains_Code_First
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Migrations;

    public class MountainsContext : DbContext
    {
        // Your context has been configured to use a 'MountainsContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Mountains_Code_First.MountainsContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'MountainsContext' 
        // connection string in the application configuration file.
        public MountainsContext()
            : base("name=MountainsContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MountainsContext, Configuration>());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.


        public virtual IDbSet<Country> Countries { get; set; }
        public virtual IDbSet<Mountain> Mountains { get; set; }
        public virtual IDbSet<Peak> Peaks { get; set; }
        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}