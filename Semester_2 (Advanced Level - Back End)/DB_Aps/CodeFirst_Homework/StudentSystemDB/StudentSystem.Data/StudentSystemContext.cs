namespace StudentSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Security.Permissions;
    using Migrations;
    using Model;

    public class StudentSystemContext : DbContext
    {
        // Your context has been configured to use a 'StudentSystemCintext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'StudentSystem.Data.StudentSystemCintext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'StudentSystemCintext' 
        // connection string in the application configuration file.
        public StudentSystemContext()
            : base("name=StudentSystemCintext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemContext, Configuration>());
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Homework> Homeworks { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<License> Licenses { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}