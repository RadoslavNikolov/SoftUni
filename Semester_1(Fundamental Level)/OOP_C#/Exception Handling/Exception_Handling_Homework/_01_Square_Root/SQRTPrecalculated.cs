using System;

namespace Square_Root
{
    static class SQRTPrecalculated
    {
        public const int MAX_VALUE = 214748364;
        private static int[] sqrtValues;

        static SQRTPrecalculated()
        {
            Console.WriteLine("I am a static constructor!");
            sqrtValues = new int[MAX_VALUE+1];
            for (int i = 0; i < sqrtValues.Length; i++)
            {
                sqrtValues[i] = (int) Math.Sqrt(i);
            }
        }

        public static int GetSqrt(int number)
        {
            return sqrtValues[number];
        }
    }
}
