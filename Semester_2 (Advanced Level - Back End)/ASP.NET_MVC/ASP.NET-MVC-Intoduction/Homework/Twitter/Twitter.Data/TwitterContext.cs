namespace Twitter.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using UnitOfWork;

    public class TwitterContext : IdentityDbContext<User>, ITwitterContext
    {
        public TwitterContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static TwitterContext Create()
        {
            return new TwitterContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Followers)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("UserId");
                    m.MapRightKey("FollowerId");
                    m.ToTable("UsersFollowers");
                });

            modelBuilder.Entity<User>()
                .HasMany(u => u.Following)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("UserId");
                    m.MapRightKey("FollowingId");
                    m.ToTable("UsersFollowing");
                });

            modelBuilder.Entity<Tweet>()
                .HasRequired<User>(p => p.Author)
                .WithMany(a => a.OwnTweets)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tweet>()
                .HasRequired<User>(p => p.WallOwner)
                .WithMany(o => o.WallTweets)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Message>()
                .HasRequired<User>(p => p.Sender)
                .WithMany(a => a.SendedMessages)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Message>()
                .HasRequired<User>(p => p.Receiver)
                .WithMany(a => a.ReceivedMessages)
                .WillCascadeOnDelete(false);



             //modelBuilder.Entity<User>()
             //   .HasMany(u => u.SendedMessages)
             //   .WithRequired(u => u.Sender)
             //   .WillCascadeOnDelete(false);

             //modelBuilder.Entity<User>()
             //    .HasMany(u => u.SendedMessages)
             //    .WithRequired(u => u.Receiver)
             //    .WillCascadeOnDelete(false);


            //modelBuilder.Entity<User>()
            //    .HasMany(u => u.Followed)
            //    .WithMany(u => u.Followers)
            //    .Map(m =>
            //    {
            //        m.MapLeftKey("FollowedId");
            //        m.MapRightKey("FollowerId");
            //        m.ToTable("UsersFollowers");
            //    });

            //modelBuilder.Entity<User>()
            //    .HasMany(u => u.Tweets)
            //    .WithRequired(t => t.Author)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<User>()
            //    .HasMany(u => u.ReTweets)
            //    .WithMany(t => t.RetweetedBy)
            //    .Map(m =>
            //    {
            //        m.MapLeftKey("RetweeterId");
            //        m.MapRightKey("TweetId");
            //        m.ToTable("UsersRetweets");
            //    });

            //modelBuilder.Entity<User>()
            //    .HasMany(u => u.FavouriteTweets)
            //    .WithMany(t => t.FavouredBy)
            //    .Map(m =>
            //    {
            //        m.MapLeftKey("FavouredTweetId");
            //        m.MapRightKey("FavouredByUserId");
            //        m.ToTable("UsersFavouriteTweets");
            //    });

            //modelBuilder.Entity<User>()
            //    .HasMany(u => u.SharedTweets)
            //    .WithMany(t => t.SharedBy)
            //    .Map(m =>
            //    {
            //        m.MapLeftKey("SharedByUserId");
            //        m.MapRightKey("SharedTweetId");
            //        m.ToTable("UsersSharedTweets");
            //    });

            //modelBuilder.Entity<User>()
            //    .HasMany(u => u.ReportedTweets)
            //    .WithMany(t => t.ReportedBy)
            //    .Map(m =>
            //    {
            //        m.MapLeftKey("ReportedByUserId");
            //        m.MapRightKey("ReportedTweetId");
            //        m.ToTable("UsersReportedTweets");
            //    });

            //modelBuilder.Entity<User>()
            //    .HasMany(u => u.SentMessages)
            //    .WithRequired(m => m.Receiver)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<User>()
            //    .HasMany(u => u.ReceivedMessages)
            //    .WithRequired(m => m.Sender)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<User>()
            //    .HasMany(u => u.Notifications)
            //    .WithRequired(n => n.ReceivedBy)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Tweet>()
            //    .HasMany(t => t.Replies)
            //    .WithOptional(t => t.RepliedToTweet)
            //    .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);

        }

        public virtual IDbSet<Tweet> Tweets { get; set; }
        public virtual IDbSet<Reply> Replies { get; set; }
        public virtual IDbSet<Message> Messages { get; set; }
        public virtual IDbSet<TweetFavorite> TweetFavorites { get; set; }
        public virtual IDbSet<TweetReport> TweetReports { get; set; }
        public virtual IDbSet<File> Files { get; set; }
    }
}