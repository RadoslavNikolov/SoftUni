using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Age
{
    class Program
    {
        static void Main(string[] args)
        {
            //int age;
            //Console.Write("Въведете вашата възраст:");
            //age = int.Parse(Console.ReadLine());
            //Console.WriteLine("Вашата възраст е:{0}", age);
            //Console.WriteLine("След десет години ще сте на {0} годишна възраст!", age + 10);

            Console.Write("Въведете вашата възраст:");
            int age = int.Parse(Console.ReadLine());
            DateTime today = DateTime.Today;
            Console.WriteLine("Вие сте роден прес {0:yyyy} година", today.AddYears(-age));


           
        }
    }
}
