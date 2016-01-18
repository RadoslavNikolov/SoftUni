using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceOfOperations
{
    using Interfaces;
    using Operations;

    class PerformanceTests
    {
        static void Main(string[] args)
        {
            int reiterationCount = 500;
            string headerRow = string.Format("n={0}|{1}|{2}|{3}|{4}|", 
                reiterationCount.ToString().PadRight(20),
                "   int  ticks".PadRight(18),
                "   long  ticks".PadRight(18),
                "   double  ticks".PadRight(18),
                "   decimal  ticks".PadRight(18));
            FileUtils.AppendLineInFile(headerRow);

            List<IMeasurable> measures = new List<IMeasurable>();
            measures.Add(new Adding(reiterationCount));
            measures.Add(new Substraction(reiterationCount));
            measures.Add(new IncrementationPrefix(reiterationCount));
            measures.Add(new IncrementationPostfix(reiterationCount));
            measures.Add(new Incrementation(reiterationCount));
            measures.Add(new Multiplication(reiterationCount));
            measures.Add(new Division(reiterationCount));
            measures.Add(new MathSqrt(reiterationCount));
            measures.Add(new MathLog(reiterationCount));
            measures.Add(new MathSin(reiterationCount));


            foreach (var measure in measures)
            {
                measure.MeasurePerformance();
                FileUtils.AppendLineInFile(measure.ToString());
            }

        }
    }
}
