using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.PractisePartTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 10, y = 5;

            Console.WriteLine("x>y: " + (x > y));
            Console.WriteLine("x<y: " + (x < y));
            Console.WriteLine("x>=y: " + (x >= y));
            Console.WriteLine("x<=y: " + (x <= y));
            Console.WriteLine("x==y: " + (x == y));
            Console.WriteLine("x!=: " + (x != y));

            
            x *= y;  //Same as x=x*y
            Console.WriteLine(x);

            Console.WriteLine(y*=2); //10
            int z = y = 3;
            x = 10;
            Console.WriteLine(z);
            Console.WriteLine(x|=1); //11
            Console.WriteLine(x+=3); //14
            Console.WriteLine(x/=2); //7

            int a = 6, b = 4;
            Console.WriteLine(a>b ? "a>b" : "a<=b");
            int num = a == b ? 1 : -1; //num will have value -1
            Console.WriteLine(num);

            Console.WriteLine(DateTime.Now); //Print the day and time

            int[] arr = {1,2,3};
            Console.WriteLine("{0} \r\n",arr[0]); //1
            for (int i = 0; i <arr.Length; i++)
            {
                Console.WriteLine(arr[i]);           
            }
            string str = "Hello";
            Console.WriteLine();
            Console.WriteLine("{0} \r\n", str[1]);
           
            for (int i = 0; i < str.Length; i++)
            {
                 Console.WriteLine(str[i]);
                
            }

            int? d = 5;
            Console.WriteLine(d??-1); //5
            string name = null;
            Console.WriteLine(name ?? "(no name)");  //(no name)

            string s = "Beer";
            Console.WriteLine(s is string); //true
            string notNullString=s;
            string nullString = null;
            Console.WriteLine(nullString ?? "Unspecified"); //Unspecified
            Console.WriteLine(notNullString ?? "Specified"); //Beer


            int myInt = 5;
            Console.WriteLine(myInt); //5
            long myLong = myInt;
            Console.WriteLine(myLong); //5
            Console.WriteLine(myInt + myLong); //10

            double myDouble = 5.1d;
            Console.WriteLine(myDouble); //5.1

            myLong = (long)myDouble; 
            Console.WriteLine(myLong);  //5

            myDouble = 5e9d; //5*10^9
            Console.WriteLine(myDouble); //5000000000
            myInt = (int)myDouble;
            Console.WriteLine(myInt); //loss of accuracy
            Console.WriteLine(int.MinValue);

            myLong = long.MaxValue;
            myInt = (int)myLong;
            Console.WriteLine(myLong);
            Console.WriteLine(myInt);


            




        }
    }
}
