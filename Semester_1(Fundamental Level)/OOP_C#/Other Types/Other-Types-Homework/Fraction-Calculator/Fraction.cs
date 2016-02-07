namespace Fraction_Calculator
{
    using System;
    using System.Globalization;
    using System.Linq;

    public struct Fraction
    {
        private long denominator;

        public Fraction(long numerator, long denominator) : this()
        {
            this.Numerator = numerator;
            this.Denominator = denominator;
        }

        public long Numerator { get; set; }

        public long Denominator
        {
            get { return this.denominator; }
            set
            {
                if (value == 0)
                {
                    throw new DivideByZeroException("Cannot divide by zero");
                }
                this.denominator = value;
            }
        }

        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            long nok = NOK(f1.Denominator, f2.Denominator);
            long newNumerator = f1.Numerator*(nok/f1.Denominator) + f2.Numerator*(nok/f2.Denominator);
            return new Fraction(newNumerator, nok);
        }

        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            long nok = NOK(f1.Denominator, f2.Denominator);
            long newNumerator = f1.Numerator * (nok / f1.Denominator) - f2.Numerator * (nok / f2.Denominator);
            return new Fraction(newNumerator, nok);
        }

        //Най-малко обшо кратно
        public static long NOK(long[] numbers)
        {
            return numbers.Aggregate(1, (x, y) => (int) (x * y))/Gcd(numbers);
        }

        public static long NOK(long a, long b)
        {
            return (a*b)/Gcd(a, b);
        }


        public static long Gcd(long[] numbers)
        {
            return numbers.Aggregate(Gcd);
        }

        public static long Gcd(long a, long b)
        {
            return b == 0 ? a : Gcd(b, a % b);
        }

        public override string ToString()
        {
            return ((decimal)this.Numerator/(decimal)this.Denominator).ToString(CultureInfo.InvariantCulture);
        }
    }
}