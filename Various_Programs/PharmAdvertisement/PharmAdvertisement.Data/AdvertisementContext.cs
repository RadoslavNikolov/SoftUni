namespace PharmAdvertisement.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Migrations;
    using Models;
    using PharmAdvertisement.Models.DAO;

    public class AdvertisementContext : DbContext
    {
        // Your context has been configured to use a 'AdvertisementModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'PharmAdvertisement.Data.AdvertisementModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'AdvertisementModel' 
        // connection string in the application configuration file.
        public AdvertisementContext()
            : base("name=AdvertisementContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AdvertisementContext, Configuration>());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual IDbSet<Drug> Drugs { get; set; }

        public virtual IDbSet<Diagnosis> Diagnoses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Diagnosis>()
                .HasMany(b => b.Drugs)
                .WithMany(a => a.Diagnoses)
                .Map(m => m.MapLeftKey("DiagnosisId")
                    .MapRightKey("DrugId")
                    .ToTable("DiagnosisToDrug"));

            base.OnModelCreating(modelBuilder);
        }

        public static AdvertisementContext Create()
        {
            return new AdvertisementContext();
        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}