namespace SportSystem.Data.UnitOfWork
{
    using Model;
    using Repositories;

    public interface ISportSystemData
    {
        IRepository<User> Users { get; }

        IRepository<Team> Teams { get; }

        IRepository<Player> Players { get; }

        IRepository<Match> Matches { get; }

        IRepository<Comment> Comments { get; }

        IRepository<UserMatchBet> UserMatchBets { get; }

        IRepository<Vote> Votes { get; }

        void SaveChanges();
    }
}