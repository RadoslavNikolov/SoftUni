using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Present_Date_and_Time
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Текущата дата и време е: {0}", DateTime.Now);
            Console.WriteLine("Текущата UTC дата и време е: {0}", DateTime.UtcNow);
            Console.WriteLine("Текущата дата и време е: {0:MM/dd.yyy HH:mm}",DateTime.Now);

            // Display date using short date string
            Console.WriteLine("Текущата дата и време е: {0:d}", DateTime.Now);

            // Display date using 24-hour clock
            Console.WriteLine("Текущата дата и време е: {0:g}", DateTime.Now);



        }
    }
}
