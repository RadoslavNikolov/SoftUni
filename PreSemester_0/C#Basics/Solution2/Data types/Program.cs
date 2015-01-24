using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_types
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Минималната стойност на типа данни SByte е: {0}", sbyte.MinValue);
            Console.WriteLine("Максималната стойност на типа данни SByte е: {0} \r\n", sbyte.MaxValue);

            Console.WriteLine("Минималната стойност на типа данни Byte е: {0}",byte.MinValue);
            Console.WriteLine("Максималната стойност на типа данни Byte е: {0} \r\n",byte.MaxValue);

            Console.WriteLine("Минималната стойност на типа данни Short е: {0}",short.MinValue);
           // Console.WriteLine("Минималната стойност на типа данни Short(Int32) е: {0}", Int16.MinValue);
            Console.WriteLine("Максималната стойност на типа данни Short е: {0} \r\n",short.MaxValue);
           // Console.WriteLine("Максималната стойност на типа данни Short(Int32) е: {0} \r\n", Int16.MaxValue);

            Console.WriteLine("Минималната стойност на типа данни UShort е: {0}", ushort.MinValue);
            //Console.WriteLine("Минималната стойност на типа данни UShort(Int16) е: {0}", UInt16.MinValue);
            Console.WriteLine("Максималната стойност на типа данни UShort е: {0} \r\n", ushort.MaxValue);
            //Console.WriteLine("Максималната стойност на типа данни UShort(Int16) е: {0} \r\n", UInt16.MaxValue);

            Console.WriteLine("Минималната стойност на типа данни Int е: {0}", int.MinValue);
            //Console.WriteLine("Минималната стойност на типа данни Int(Int32) е: {0}", Int32.MinValue);
            Console.WriteLine("Максималната стойност на типа данни Int е: {0} \r\n", int.MaxValue);
            //Console.WriteLine("Максималната стойност на типа данни Int(Int32) е: {0} \r\n",Int32.MaxValue);

            Console.WriteLine("Минималната стойност на типа данни UInt е: {0}", uint.MinValue);
            //Console.WriteLine("Минималната стойност на типа данни UInt(UInt32) е: {0}", UInt32.MinValue);
            Console.WriteLine("Максималната стойност на типа данни UInt е: {0} \r\n", uint.MaxValue);
            //Console.WriteLine("Максималната стойност на типа данни UInt(UInt32) е: {0} \r\n", UInt32.MaxValue);

            Console.WriteLine("Минималната стойност на типа данни Long е: {0}", long.MinValue);
            //Console.WriteLine("Минималната стойност на типа данни Long(Int64) е: {0}", Int64.MinValue);
            Console.WriteLine("Максималната стойност на типа данни Long е: {0} \r\n", long.MaxValue);
            //Console.WriteLine("Максималната стойност на типа данни Long(Int64) е: {0} \r\n", Int64.MaxValue);

            Console.WriteLine("Минималната стойност на типа данни ULong е: {0}", ulong.MinValue);
            //Console.WriteLine("Минималната стойност на типа данни ULong(UInt64) е: {0}", UInt64.MinValue);
            Console.WriteLine("Максималната стойност на типа данни ULong е: {0} \r\n", ulong.MaxValue);
            //Console.WriteLine("Максималната стойност на типа данни ULong(UInt64) е: {0} \r\n", UInt64.MaxValue);

            byte centuries = 20;
            ushort years = 2000;
            uint days = 730480;
            ulong hours = 17531520;

            Console.WriteLine(centuries + " centuries are " + years + " years, or " + days + " days, or " + hours + " hours ");

            Console.WriteLine("Минималната стойност на типа данни Float е: {0}", float.MinValue);
            //Console.WriteLine("Минималната стойност на типа данни Float(Single) е: {0}", Single.MinValue);
            Console.WriteLine("Максималната стойност на типа данни Float е: {0}", float.MaxValue);
            //Console.WriteLine("Максималната стойност на типа данни Float(Single) е: {0} \r\n", Single.MaxValue);
            Console.WriteLine("Най-блозкото до нула положително число от тип float е: {0}", float.Epsilon);
            Console.WriteLine("Минус безкрайност е: {0}", Single.NegativeInfinity);
            Console.WriteLine("Плюс безкрайност е: {0}", float.PositiveInfinity);
            Console.WriteLine("Неопределеност е: {0} \r\n", Single.NaN);

            Console.WriteLine("Минималната стойност на типа данни Doubl;e е: {0}", double.MaxValue);
            Console.WriteLine("Максималната стойност на типа данни Double е: {0}", double.MaxValue);
            Console.WriteLine("Най-блозкото до нула положително число от тип double е: {0}", double.Epsilon);
            Console.WriteLine("Минус безкрайност е: {0}", double.NegativeInfinity);
            Console.WriteLine("Плюс безкрайност е: {0}", double.PositiveInfinity);
            Console.WriteLine("Неопределеност е: {0} \r\n", double.NaN);



            float floatPI = 3.14159265358979323846f;
            double doublePI = 3.14159265358979323846;
            decimal decimalPI = 3.14159265358979323846m;
            Console.WriteLine("Float PI is: " + floatPI);
            Console.WriteLine("Double PI is: " +doublePI);
            Console.WriteLine("Decimal PI is: {0} \r\n",decimalPI);



            int a = 1;
            int b = 2;
            bool greaterAB =(a>b);
            Boolean equalAto1 =(a==1);
            if (greaterAB)
            {
                Console.WriteLine("A>B");
            }
            else
            {
                Console.WriteLine("A<=B");
            }
            Console.WriteLine("greaterAB= "+greaterAB);
            Console.WriteLine("equalAto1= " + equalAto1 + "\r\n");



            char symbol='a';
            Console.WriteLine("The code of ' " + symbol + " ' symbol is: " + (int)symbol);
            symbol='b';
            Console.WriteLine("The code of ' " + symbol + " ' symbol is: " + (int)symbol);
            symbol='A';
            Console.WriteLine("The code of ' " + symbol + " ' symbol is: " + (int)symbol + "\r\n");


            string firstName = "Radoslav";
            string lastName = "Nikolov";
            string fullName = firstName + " " + lastName;
            Console.WriteLine("Heloo {0}!",firstName);
            Console.WriteLine("You full name is: {0} \r\n", fullName);


            object container1 = 5;
            object container2 = "Five";
            Console.WriteLine("The value of container1 is: " + container1);
            Console.WriteLine("The value of container2 is: " + container2 + "\r\n");

            int i = 5;
            int? ni = i;
            Console.WriteLine(ni.HasValue);
            i = ni.Value;
            Console.WriteLine(i);
            ni = null;
            Console.WriteLine(ni.HasValue);
            i = ni.GetValueOrDefault();
            Console.WriteLine(i);



        }
    }
}
