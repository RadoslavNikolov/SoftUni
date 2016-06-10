namespace Portal.Data.UnitOfWork
{
    using Models.IdentityModels;
    using Repositories;

    public interface IApplicationData
    {
        IRepository<ApplicationUser> Users { get; }

        void SaveChanges();
    }
}