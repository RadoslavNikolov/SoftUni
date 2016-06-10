namespace Portal.Data.Repositories
{
    using System;

    public interface IContestsDbContext : IDisposable
    {
        int SaveChanges();
    }
}