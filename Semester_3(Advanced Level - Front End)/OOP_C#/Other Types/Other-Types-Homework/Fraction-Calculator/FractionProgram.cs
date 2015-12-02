namespace Fraction_Calculator
{
    using System;

    class FractionProgram
    {
        static void Main()
        {
            Console.WriteLine(Fraction.NOK(15,38));
            Console.WriteLine(Fraction.NOK(new long[]{15,38}));

            Fraction fraction1 = new Fraction(22, 7);
            Fraction fraction2 = new Fraction(40, 4);
            Fraction result = fraction1 + fraction2;
            Console.WriteLine(result.Numerator);
            Console.WriteLine(result.Denominator);
            Console.WriteLine(result);

            fraction1 = new Fraction(83, 7);
            fraction2 = new Fraction(40, 4);
            result = fraction1 - fraction2;
            Console.WriteLine(result.Numerator);
            Console.WriteLine(result.Denominator);
            Console.WriteLine(result);

        }
    }
}
