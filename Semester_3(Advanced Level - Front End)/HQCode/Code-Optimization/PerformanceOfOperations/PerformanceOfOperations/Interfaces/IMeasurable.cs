namespace PerformanceOfOperations.Interfaces
{
    using System.Collections.Generic;

    public interface IMeasurable
    {
        int ReiterationCount { get;}

        IEnumerable<double> GetResults { get; } 

        void AddResult(double result);

        void MeasurePerformance();
    }
}