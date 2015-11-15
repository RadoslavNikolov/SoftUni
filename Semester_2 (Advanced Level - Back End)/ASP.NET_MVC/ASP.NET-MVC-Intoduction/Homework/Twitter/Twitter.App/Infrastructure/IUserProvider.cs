namespace Twitter.App.Infrastructure
{
    public interface IUserProvider
    {
        bool IsAuthenticated { get; }

        string GetUserId();
    }
}