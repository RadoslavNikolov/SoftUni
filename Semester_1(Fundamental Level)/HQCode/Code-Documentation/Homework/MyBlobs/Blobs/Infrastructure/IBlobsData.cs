namespace Blobs.Infrastructure
{
    using System.Collections.Generic;
    using Models.Inftrastructure;

    /// <summary>
    /// Interface for classes capable of storing collections with game units
    /// </summary>
    public interface IBlobsData
    {
        /// <summary>
        /// Public property for the collection storing blobs
        /// </summary>
        IEnumerable<IUnit> Blobs { get; }

        /// <summary>
        /// Adds units whicha are implementing <see cref="Blobs.Models.Inftrastructure.IUnit"/> to certain collection
        /// </summary>
        /// <param name="unit">Unit to store</param>
        void AddBlob(IUnit unit);

        /// <summary>
        /// Returns units whicha are implementing <see cref="Blobs.Models.Inftrastructure.IUnit"/> from certain collection by givven name
        /// </summary>
        /// <param name="unitName">Name of unit</param>
        /// <returns></returns>
        IUnit GetUnit(string unitName);
    }
}