using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Sand_Glass
{
    class sandGlass
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int count=1;

            for (int i = 0; i < n; i++)
            {
                if (i==0 || i==n-1)
                {
                    string edgeLine = new string('*', n);
                    Console.WriteLine(edgeLine);
                }             
                else if(i<=n/2 && i>0)
                {
                    string otherLine = new string('.', i) + new string('*',n-2*i) + new string('.',i);
                    count++;
                    Console.WriteLine(otherLine);
                }
                else if (i>n/2 && i<n-1)
                {
                    count--;
                    string otherLine = new string('.', n-i-1) + new string('*', n-2*(n-i-1)) + new string('.', n-i-1);
                    Console.WriteLine(otherLine);
                }
            }
        }
    }
}
