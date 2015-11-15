using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Reverse_numbers_with_stack
{
    using System.Text.RegularExpressions;

    class ReverseNumbers
    {
        static void Main(string[] args)
        {

            var myStack = new Stack<int>();
            Console.Write("Enter sequence of numbers or \"Ctrl + C\" for exit:  ");
            string line = "";

            do
            {
                line = Console.ReadLine().Trim();

                if (!string.IsNullOrEmpty(line))
                {
                    int[] inputArr = Regex.Matches(line, @"[0-9]+").Cast<Match>()
                        .Select(m => int.Parse(m.Value))
                        .ToArray();

                    foreach (int num in inputArr)
                    {
                        myStack.Push(num);
                    }

                    while (myStack.Count > 0)
                    {
                        Console.Write("{0} ", myStack.Pop());
                    }

                    Console.WriteLine();
                }             
            } while (line != null);

        }
    }
}
