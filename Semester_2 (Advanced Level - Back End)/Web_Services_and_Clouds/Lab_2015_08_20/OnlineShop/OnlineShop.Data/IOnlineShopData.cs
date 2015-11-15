namespace OnlineShop.Data
{
    using Models;
    using Repositories;

    public interface IOnlineShopData
    {
        IRepository<Ad> Ads { get; }

        IRepository<AdType> AdTypes { get; }

        IRepository<ApplicationUser> ApplicationUsers { get; } 
        
        IRepository<Category> Categories { get; } 

        int SaveChanges();
    }
}