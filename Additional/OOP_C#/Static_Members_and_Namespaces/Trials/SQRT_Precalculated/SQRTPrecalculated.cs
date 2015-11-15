using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQRT_Precalculated
{
    static class SQRTPrecalculated
    {
        public const int MAX_VALUE = 100000001;
        private static int[] sqrtValues;

        static SQRTPrecalculated()
        {
            Console.WriteLine("I am a static constructor");
            sqrtValues = new int[MAX_VALUE + 1];
            for (int i = 0; i < sqrtValues.Length; i++)
            {
                sqrtValues[i] = (int) Math.Sqrt(i);
            }
        }

        public static int GetSqrt(int value)
        {
            return sqrtValues[value];
        }
    }

    class SqrtTest
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(SQRTPrecalculated.GetSqrt(254));


            //test time differences
            DateTime first = DateTime.Now;
            for (int i = 0; i < 100000001; i++)
            {
                int result = (int) Math.Sqrt(i);
            }
            TimeSpan normalSqrtCalculation = DateTime.Now - first;
            DateTime second = DateTime.Now;
            for (int i = 0; i < 100000001; i++)
            {
                int resultNew = SQRTPrecalculated.GetSqrt(i);
            }
            TimeSpan precalculatedSQRT = DateTime.Now - second;
            Console.WriteLine("Just compare performance");
            Console.WriteLine("Sieve with standart SQRT calculation: {0}", normalSqrtCalculation);
            Console.WriteLine("Sieve with precalculated SQRT: {0}", precalculatedSQRT);
        } 
    }
}
