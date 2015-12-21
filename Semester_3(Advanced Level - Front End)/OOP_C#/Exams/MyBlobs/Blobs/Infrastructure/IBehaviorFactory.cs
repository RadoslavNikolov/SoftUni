namespace Blobs.Infrastructure
{
    using Models.Inftrastructure;

    public interface IBehaviorFactory
    {
        IBehavior CreateBehavior(string behaviorType);
    }
}