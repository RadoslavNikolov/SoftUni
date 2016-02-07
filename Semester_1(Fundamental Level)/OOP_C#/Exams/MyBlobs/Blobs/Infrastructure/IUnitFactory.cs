namespace Blobs.Infrastructure
{
    using System.Collections.Generic;
    using Models.Inftrastructure;

    public interface IUnitFactory
    {
        IUnit CreateUnit(IList<string> parameters);
    }
}