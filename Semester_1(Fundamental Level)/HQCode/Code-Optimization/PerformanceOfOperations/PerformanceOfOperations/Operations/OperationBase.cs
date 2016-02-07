namespace PerformanceOfOperations.Operations
{
    using System.Collections.Generic;
    using System.Text;
    using Interfaces;
    public abstract class OperationBase : IMeasurable
    {
        private readonly IList<double> results;
         
        protected OperationBase(int reiterationCount)
        {
            this.ReiterationCount = reiterationCount;
            this.results = new List<double>();
        }

        public int ReiterationCount { get; private set; }

        public IEnumerable<double> GetResults => this.results;

        public void AddResult(double result)
        {
            this.results.Add(result);
        }

        public abstract void MeasurePerformance();

        public override string ToString()
        {
            var output = new StringBuilder();
            output.Append(string.Format("{0}", this.GetType().Name.PadRight(22)));
            foreach (var result in this.GetResults)
            {
                output.Append(string.Format("|{0}", result.ToString().PadRight(18)));
            }
            return output.ToString();
        }
    }
}