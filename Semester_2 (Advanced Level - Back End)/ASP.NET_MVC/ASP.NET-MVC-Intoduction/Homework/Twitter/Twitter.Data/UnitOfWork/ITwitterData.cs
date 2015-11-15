namespace Twitter.Data.UnitOfWork
{
    using Contracts;
    using Microsoft.AspNet.Identity;
    using Models;

    public interface ITwitterData
    {
        IRepository<User> Users { get; }

        IRepository<Tweet> Tweets { get; }

        IRepository<TweetFavorite> TweetFavorites { get; }

        IRepository<Reply> Replies { get; }

        IRepository<Message> Messages { get; }

        IRepository<TweetReport> TweetReports { get; }

        IRepository<File> Files { get; }

        IUserStore<User> UserStore { get; }

        void SaveChanges();
    }
}