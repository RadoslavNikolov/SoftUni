namespace Huy_Phuong.Infrastructure
{
    using System.Collections.Generic;

    public interface ITheatre
    {
        string Name { get; }

        IEnumerable<IPerformance> Performances { get;}

        void AddPerformance(IPerformance performance);
    }
}