namespace SportSystem.Data.Repositories
{
    using System;

    public interface ISportSystemDbContext : IDisposable
    {
        int SaveChanges();
    }
}