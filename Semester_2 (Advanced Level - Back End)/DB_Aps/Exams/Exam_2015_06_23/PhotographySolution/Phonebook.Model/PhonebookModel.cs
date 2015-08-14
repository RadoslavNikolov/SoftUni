namespace Phonebook.Model
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Migrations;

    public class PhonebookModel : DbContext
    {
 
        public PhonebookModel()
            : base("name=PhonebookModel")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PhonebookModel, Configuration>());
        }

        public virtual IDbSet<Channel> Channels { get; set; }
        public virtual IDbSet<ChannelMessage> ChannelMessages { get; set; }
        public virtual IDbSet<User> Users { get; set; }
        public virtual IDbSet<UserMessage> UserMessages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserMessage>()
                .HasRequired(x => x.Sender)
                .WithMany(x => x.SentMessage)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserMessage>()
                .HasRequired(x => x.Recipient)
                .WithMany(x => x.RecievedMessage)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}