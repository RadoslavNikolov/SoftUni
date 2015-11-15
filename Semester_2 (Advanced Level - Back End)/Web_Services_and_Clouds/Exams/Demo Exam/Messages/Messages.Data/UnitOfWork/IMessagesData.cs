namespace Messages.Data.UnitOfWork
{
    using Microsoft.AspNet.Identity;
    using Models;
    using Reppositories;

    public interface IMessagesData
    {
        IRepository<User> Users { get; }

        IRepository<Channel> Channels { get; }

        IRepository<ChannelMessage> ChannelMessages { get; }

        IRepository<UserMessage> UserMessages { get; }

        IUserStore<User> UserStore { get; }

        void SaveChanges();
    }
}