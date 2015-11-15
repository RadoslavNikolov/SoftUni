namespace Snippy.Data.Repositories
{
    using System;

    public interface ISnippyDbContext : IDisposable
    {
        int SaveChanges();
    }
}