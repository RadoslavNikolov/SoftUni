using System;

namespace Square_Root
{
    public class Test
    {
        static void Main()
        {
            try
            {
                Console.Write("Please enter an integer to calculate its square root: ");
                int number = int.Parse(Console.ReadLine());
                if (number < 0)
                {
                    throw new ArgumentOutOfRangeException("nuber", "Invalid number. Must be positive!");
                }
                //test time differences
                DateTime first = DateTime.Now;
                for (int i = 0; i < 10000001; i++)
                {
                    int result = (int) Math.Sqrt(i);
                }
                TimeSpan normalSqrtCalculation = DateTime.Now - first;
                DateTime second = DateTime.Now;
                for (int i = 0; i < 10000001; i++)
                {
                    int resultNew = SQRTPrecalculated.GetSqrt(i);
                }
                TimeSpan precalculatedSQRT = DateTime.Now - second;
                Console.WriteLine("Just compare performance");
                Console.WriteLine("Sieve with standart SQRT calculation: {0}", normalSqrtCalculation);
                Console.WriteLine("Sieve with precalculated SQRT: {0}", precalculatedSQRT);
                Console.WriteLine();
                Console.WriteLine(Math.Sqrt(number));
                Console.WriteLine(SQRTPrecalculated.GetSqrt(number));
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid Number!");
                Console.WriteLine(ex);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Console.WriteLine("Good bye!");
            }
        } 
    }
}