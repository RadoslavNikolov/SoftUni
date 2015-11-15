namespace Reverse_Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ReverseNumbers
    {
        static void Main()
        {
            var line = "";
            var numberStack = new Stack<int>();

            while (true)
            {
                numberStack.Clear();

                Console.Write("Enter sequence of numbers or \"exit\": ");
                line = Console.ReadLine().Trim().ToLower();

                if (line == "")
                {
                    continue;
                }

                if (line == "exit")
                {
                    break;
                }

                var numbers = line.Split(' ').Select(Int32.Parse).ToList();
                numbers.ForEach(n => numberStack.Push(n));

                while (numberStack.Count > 0)
                {
                    Console.Write("{0} ", numberStack.Pop());
                }

                Console.WriteLine();
            }
        }
    }
}
