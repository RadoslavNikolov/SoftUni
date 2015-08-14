namespace ShopSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Migrations;
    using Model;

    public class ShopEntities : DbContext
    {
        // Your context has been configured to use a 'ShopEntities' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'ShopSystem.Data.ShopEntities' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ShopEntities' 
        // connection string in the application configuration file.
        public ShopEntities()
            : base("name=ShopEntities")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ShopEntities, Configuration>());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual IDbSet<User> Users { get; set; }
        public virtual IDbSet<Category> Categories { get; set; }
        public virtual IDbSet<Product> Products { get; set; }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}