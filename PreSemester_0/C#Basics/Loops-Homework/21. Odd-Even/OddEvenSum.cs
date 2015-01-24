using System;
using System.Threading;

class oddEvenSum
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("en-US");
        string strNumber = Console.ReadLine().Trim();
        string[] number = strNumber.Split(' ');
        decimal oddSum = 0;
        decimal evenSum = 0;
        decimal oddMin = decimal.MaxValue;
        decimal oddMax = decimal.MinValue;
        decimal evenMin = decimal.MaxValue;
        decimal evenMax = decimal.MinValue;

        if (strNumber == "")
        {
            number = new string[0];
        }
        if (number.Length > 1)
        {
            for (int i = 0; i < number.Length; i++)
            {
                decimal element = decimal.Parse(number[i]);
                if ((i + 1) % 2 != 0)
                {
                    oddSum += element;
                    oddMin = Math.Min(oddMin, element);
                    oddMax = Math.Max(oddMax, element);
                }
                else
                {
                    evenSum += element;
                    evenMin = Math.Min(evenMin, element);
                    evenMax = Math.Max(evenMax, element);
                }
            }
            Console.WriteLine("OddSum={0}, OddMin={1}, OddMax={2}, EvenSum={3}, EvenMin={4}, EvenMax={5}", (double)oddSum, (double)oddMin, (double)oddMax, (double)evenSum, (double)evenMin, (double)evenMax);
        }
        else if (number.Length == 1)
        {
            decimal elemnt = decimal.Parse(number[0]);
            oddSum = elemnt;
            oddMin = elemnt;
            oddMax = elemnt;
            Console.WriteLine("OddSum={0}, OddMin={1}, OddMax={2}, EvenSum=No, EvenMin=No, EvenMax=No", (double)oddSum, (double)oddMin, (double)oddMax);
        }
        else
        {
            Console.WriteLine("OddSum=No, OddMin=No, OddMax=No, EvenSum=No, EvenMin=No, EvenMax=No");
        }
    }
}
