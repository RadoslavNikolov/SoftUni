namespace NewsDB.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Migrations;
    using Model;

    public class NewsDBContext : DbContext
    {
        // Your context has been configured to use a 'NewsDBContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'NewsDB.Data.NewsDBContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'NewsDBContext' 
        // connection string in the application configuration file.
        public NewsDBContext()
            : base("name=NewsDBContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<NewsDBContext, Configuration>());

        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public IDbSet<New> News { get; set; }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}