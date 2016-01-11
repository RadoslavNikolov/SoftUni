namespace Blobs.Infrastructure
{
    using Models.Inftrastructure;

    /// <summary>
    /// Interface for factory classes capable of creating attacks
    /// </summary>
    public interface IAttackFactory
    {
        /// <summary>
        /// Create instance of attack class from given attack name
        /// </summary>
        /// <param name="attackType">Given attack type as <see cref="System.String"/></param>
        /// <returns>Instance of attack class as interface <see cref="Blobs.Models.Inftrastructure.IAttack"/></returns>
        IAttack CreateAttack(string attackType); 
    }
}