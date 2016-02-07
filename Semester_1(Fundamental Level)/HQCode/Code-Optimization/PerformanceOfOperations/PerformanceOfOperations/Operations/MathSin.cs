namespace PerformanceOfOperations.Operations
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    public class MathSin : OperationBase
    {
        public MathSin(int reiterationCount) : base(reiterationCount)
        {
        }

        public override void MeasurePerformance()
        {
            int intSample = 90;
            this.AddResult(this.ProcessCalculation(intSample));

            long longSample = 90;
            this.AddResult(this.ProcessCalculation(longSample));

            double doubleSample = 90.0;
            this.AddResult(this.ProcessCalculation(doubleSample));

            decimal decimalSample = 90.0m;
            this.AddResult(this.ProcessCalculation((double)decimalSample));
        }

        private double ProcessCalculation<T>(T sample)
        {
            Stopwatch timer = new Stopwatch();
            double temp = 0;
            dynamic a = sample;
            List<long> tempResults = new List<long>();

            for (int i = 0; i < this.ReiterationCount; i++)
            {
                timer.Start();

                temp = Math.Sin(a);

                timer.Stop();
                tempResults.Add(timer.ElapsedTicks);
                timer.Restart();
            }

            tempResults.RemoveAt(0);
            tempResults.RemoveAt(tempResults.Count - 1);
            var result = tempResults.Average();
            return result;
        }
    }
}