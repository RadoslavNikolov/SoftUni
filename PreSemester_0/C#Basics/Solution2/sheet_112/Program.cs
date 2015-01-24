using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sheet_112
{
    class Program
    {
        static void Main(string[] args)
        {
            string number;
            Console.WriteLine("Моля, въведете число");
            number = Console.ReadLine();

            Console.WriteLine("Въведенето от вас чиско е: {0}", number);
            Console.WriteLine("");

            int count = 0;
            foreach (char s in number)
            {
                count++;
                Console.WriteLine("Цифра #{0} e: {1}", count, s);
            }
            Console.WriteLine("Броят на цифрите е:{0}", count);

            //for (int i = 0; i < number.Length; i++)
            //{
            //    Console.WriteLine("Цифра #{0} e: {1}", i+1, number[i]);
            //}

            //Console.WriteLine("Броят на цифрите е:{0}",number.Length);

        }
    }
}
