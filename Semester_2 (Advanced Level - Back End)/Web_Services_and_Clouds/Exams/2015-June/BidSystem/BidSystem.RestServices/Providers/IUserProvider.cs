namespace BidSystem.RestServices.Providers
{
    public interface IUserProvider
    {
        bool IsAuthenticated { get; }

        string GetUserId();
    }
}