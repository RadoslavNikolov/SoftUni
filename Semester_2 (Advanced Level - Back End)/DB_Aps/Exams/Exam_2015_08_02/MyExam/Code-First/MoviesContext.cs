namespace Code_First
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Migrations;
    using Model;

    public class MoviesContext : DbContext
    {
        // Your context has been configured to use a 'MoviesContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Code_First.MoviesContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'MoviesContext' 
        // connection string in the application configuration file.
        public MoviesContext()
            : base("name=MoviesContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MoviesContext, Configuration>());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual IDbSet<Country> Countries { get; set; }
        public virtual IDbSet<User> Users { get; set; }
        public virtual IDbSet<Movie> Movies { get; set; }
        public virtual IDbSet<Rating> Ratingses { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}