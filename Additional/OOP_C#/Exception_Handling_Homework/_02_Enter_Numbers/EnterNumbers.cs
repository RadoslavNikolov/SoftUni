using System;
using System.Linq;

namespace _02_Enter_Numbers
{
    class EnterNumbers
    {
        public static void Main()
        {
            int[] userNumbers = new int[10];

            for (int i = 0; i < 10; i++)
            {
                int start = Math.Max(1, userNumbers.Max());
                int end = 100;
                userNumbers[i] = ReadNumbers(start, end);
            }

            Console.WriteLine("\nEntered numbers:");
            for (int i = 0; i < userNumbers.Length; i++)
            {
                Console.WriteLine("Number[{0}]: {1}", i+1, userNumbers[i]);
            }
        }

        public static int ReadNumbers(int start, int end)
        {
            bool success = false;
            int number = new int();
            while (!success)
            {
                try
                {
                    Console.Write("Enter numeber in range[{0} < number < {1}]: ", start, end);
                    number = int.Parse(Console.ReadLine());
                    if (number <= start || number >= end)
                    {
                        throw new ArgumentOutOfRangeException();
                    }                 
                    success = true;
                }
                catch (FormatException)
                {

                    Console.WriteLine("You should enter integer number. Try again:");
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Number should be in the range [{0} < number < {1}]. Try again:", start, end);
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine(ex.Message + " Try again:");
                }

            }

            return number;
        }
    }
}
