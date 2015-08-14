namespace CodeFirst_Model
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Migrations;
    using Model;

    public class PhonebookModel : DbContext
    {
        public PhonebookModel()
            : base("name=PhonebookModel")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PhonebookModel, Configuration>());
        }

        public virtual IDbSet<Contact> Contacts { get; set; }

        public virtual IDbSet<Email> Emails { get; set; }

        public virtual IDbSet<Phone> Phones { get; set; }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}