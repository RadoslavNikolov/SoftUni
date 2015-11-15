namespace BugTracker.Data.UnitOfWork
{
    using Microsoft.AspNet.Identity;
    using Models;
    using Repositories;

    public interface IBugTrackerData
    {
        IRepository<User> Users { get; }

        IRepository<Bug> Bugs { get; }

        IRepository<Comment> Comments { get; }

        IUserStore<User> UserStore { get; }

        void SaveChanges(); 
    }
}