namespace Blobs.Infrastructure
{
    using System.Collections.Generic;
    using Models.Inftrastructure;

    public interface IBlobsData
    {
        IEnumerable<IUnit> Blobs { get; }

        void AddBlob(IUnit unit);

        IUnit GetUnit(string unitName);
    }
}