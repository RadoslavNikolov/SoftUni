using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Exercise
{
    using System.Numerics;
    using System.Text.RegularExpressions;

    class ArraySliderProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter input line. Non-negative integer numbers separated by whitespaces (one or more) ");
            var inputLine = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(inputLine) && inputLine.ToLowerInvariant() != "stop")
            {
                Console.WriteLine("Enter input line. Non-negative integer numbers separated by whitespaces (one or more) ");
                inputLine = Console.ReadLine();
            }

            BigInteger[] inputArray = Regex.Split(inputLine, "\\s+").Where(element => element != "").Select(element => BigInteger.Parse(element)).ToArray();
            var command = Console.ReadLine().ToLowerInvariant();
            long i = 0;
            while (command != "stop")
            {
                if (string.IsNullOrWhiteSpace(command))
                {
                    continue;
                }

                var commandTokens = command.Split(' ');
                var offset = long.Parse(commandTokens[0]);
                var operation = commandTokens[1];
                var operand = long.Parse(commandTokens[2]);

                offset = offset % inputArray.Length;
                i += offset;
                var pos = i % inputArray.Length;

                if (pos < 0)
                {
                    pos += inputArray.Length;
                }
                if (pos >= inputArray.Length)
                {
                    pos -= inputArray.Length;
                }

                inputArray[pos] = ProcessOreration(operation, inputArray, pos, operand);

                command = Console.ReadLine();
            }

            for (int element = 0; element < inputArray.Length; element++)
            {
                if (inputArray[element] < 0)
                {
                    inputArray[element] = 0;
                }
            }
            Console.WriteLine("[" + string.Join(", ", inputArray) + "]");
        }

        private static BigInteger ProcessOreration(string operation, BigInteger[] inputArray, long pos, long operand)
        {
            inputArray[pos] = 0;

            switch (operation)
            {
                case "+":
                    if ((inputArray[pos] + operand) >= 0)
                    {
                        inputArray[pos] = inputArray[pos] + operand;
                    }
                    break;
                case "-":
                    if (inputArray[pos] >= operand)
                    {
                        inputArray[pos] = inputArray[pos] - operand;
                    }
                    break;
                case "*":
                    if ((inputArray[pos]*operand) >= 0)
                    {
                        inputArray[pos] = inputArray[pos] * operand;
                    }
                    break;
                case "/":
                    if ((inputArray[pos]/operand) >= 0)
                    {
                        inputArray[pos] = inputArray[pos] / operand;
                    }
                    break;
                case "&":
                    if ((inputArray[pos] & operand) >= 0)
                    {
                        inputArray[pos] = inputArray[pos] & operand;
                    }
                    break;
                case "|":
                    if ((inputArray[pos] | operand) >= 0)
                    {
                        inputArray[pos] = inputArray[pos] | operand;
                    }
                    break;
                case "^":
                    if ((inputArray[pos] ^ operand) >= 0)
                    {
                        inputArray[pos] = inputArray[pos] ^ operand;
                    }
                    break;
                default: break;                
            }

            return inputArray[pos];
        }
    }
}
