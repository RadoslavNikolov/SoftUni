namespace BidSystem.Data.UnitOfWork
{
    using Microsoft.AspNet.Identity;
    using Models;
    using Repositories;

    public interface IBidSystemData
    {
        IRepository<User> Users { get; }

        IRepository<Bid> Bids { get; }

        IRepository<Offer> Offers { get; }

        IUserStore<User> UserStore { get; }

        void SaveChanges();
    }
}