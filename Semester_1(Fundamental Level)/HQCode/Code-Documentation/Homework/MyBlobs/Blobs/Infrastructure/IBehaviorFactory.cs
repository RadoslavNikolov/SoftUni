namespace Blobs.Infrastructure
{
    using Models.Inftrastructure;

    /// <summary>
    /// Interface for factory classes capable of creating bahavious
    /// </summary>
    public interface IBehaviorFactory
    {
        /// <summary>
        /// Create instance of behavior class from given behavior name
        /// </summary>
        /// <param name="behaviorType">Given bahavior type as <see cref="System.String"/></param>
        /// <returns>Instance of behavior class as interface <see cref="Blobs.Models.Inftrastructure.IBehavior"/></returns>
        IBehavior CreateBehavior(string behaviorType);
    }
}