using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.PractisePartOne
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 7 + 9;
            Console.WriteLine(a); //16

            string firstName = "Radoslav";
            string lastName = "Nikolov";
            string fullName = firstName + " " + lastName;
            Console.WriteLine(fullName); //Radoslav Nikolov

            double b = 5.0 / 2.0;
            //or  float b=5f/2f  but not int=5/2
            Console.WriteLine(b); //2.5

            int squarePerimeter = 17;
            double squareSide = squarePerimeter / 4.0;
            double squareArea = squareSide * squareSide;
            Console.WriteLine(squareSide);  //4.25
            Console.WriteLine(squareArea);  //18.0625

            
            a = 5;
            b = 4;
            Console.WriteLine(a + b); //9
            Console.WriteLine(a + b++); //9
            Console.WriteLine(a + b); //10
            Console.WriteLine(a + (++b)); //11
            Console.WriteLine(a + b); //11
            Console.WriteLine(14/a); //2 integer devision целочислено деление
            Console.WriteLine(14%a); //4  remainder of integer devision  остатък от целочислено деление

            int one = 1;
            int zero = 0;
            //Console.WriteLine(one / zero); //System.DivideByZeroException

            double dMinusOne = -1;
            double dZero = 0.0;
            Console.WriteLine(dMinusOne/dZero);  //-Infinity
            Console.WriteLine(one/dZero);  //Infinity

            bool c = true;
            bool d = false;
            Console.WriteLine(c && d); //False
            Console.WriteLine(c || d); //True
            Console.WriteLine(!d);  //True
            Console.WriteLine(d || true);  //True
            Console.WriteLine((5 > 7) ^ (c == d)); //False

            byte e = 3; //0000 0011=3
            byte f = 5; //0000 0101=5

            Console.WriteLine(e|f);  //0000 0111=7
            Console.WriteLine(e & f); //0000 0001=1
            Console.WriteLine(e ^ f); //0000 0110=6
            Console.WriteLine(~e & f); //0000 0100=4
            Console.WriteLine(e << 1); //0000 0110=6
            Console.WriteLine(e << 2); //0000 1100=12
            Console.WriteLine(e >> 1); //0000 0001=1





        }
    }
}
