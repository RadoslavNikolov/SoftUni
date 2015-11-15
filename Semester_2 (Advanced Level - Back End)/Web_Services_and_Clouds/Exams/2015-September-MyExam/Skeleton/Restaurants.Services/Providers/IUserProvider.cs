namespace Restaurants.Services.Providers
{
    public interface IUserProvider
    {
        bool IsAuthenticated { get; }

        string GetUserId();
    }
}