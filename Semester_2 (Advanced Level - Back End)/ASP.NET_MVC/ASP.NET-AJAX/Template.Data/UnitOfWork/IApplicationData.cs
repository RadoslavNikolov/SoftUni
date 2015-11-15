namespace Template.Data.UnitOfWork
{
    using Models;
    using Repositories;

    public interface IApplicationData
    {
        IRepository<User> Users { get; }

        IRepository<Town> Towns { get; } 

        void SaveChanges();
    }
}