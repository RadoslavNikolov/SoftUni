namespace Restaurants.Data.UnitOfWork
{
    using Microsoft.AspNet.Identity;
    using Models;
    using Repositories;
    using Restauranteur.Models;

    public interface IRestaurantData
    {
        IRepository<User> Users { get; }

        IRepository<Meal> Meals { get; }

        IRepository<MealType> MealTypes { get; }

        IRepository<Order> Orders { get; }

        IRepository<Rating> Ratings { get; }

        IRepository<Restaurant> Restaurants { get; }

        IRepository<Town> Towns { get; }

        IUserStore<User> UserStore { get; }

        void SaveChanges();
    }
}