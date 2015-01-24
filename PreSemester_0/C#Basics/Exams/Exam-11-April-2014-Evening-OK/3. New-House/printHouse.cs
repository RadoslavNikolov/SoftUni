using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.New_House
{
    class printHouse
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int count = 1;
            while (count <= n)
            {
                string line = new string('-', (n - count) / 2) + new string('*', count) + new string('-', (n - count) / 2);
                Console.WriteLine(line);
                count += 2;
            }

            for (int i = 0; i < n; i++)
            {
                string line = "|" + new string('*', n - 2) + "|";
                Console.WriteLine(line);
            }
        }
    }
}
