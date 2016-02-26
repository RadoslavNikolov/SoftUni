namespace Array_Slider
{
    using System;
    using System.Dynamic;
    using System.Linq;
    using System.Numerics;
    using System.Text.RegularExpressions;

    public class ArraySlider
    {
        private static BigInteger[] numsArray;
        private static int currentIndex = 0;
        public static void Main()
        {
            var inputLine = Console.ReadLine().Trim();
            numsArray = Regex.Split(inputLine, @"\s+", RegexOptions.IgnoreCase).Select(BigInteger.Parse).ToArray();


            while (true)
            {
                inputLine = Console.ReadLine();

                if (inputLine.ToLower().Equals("stop"))
                {
                    break;
                }

                var commandTokens = Regex.Split(inputLine, @"\s+", RegexOptions.IgnoreCase).ToArray();

                ProcessCommand(commandTokens);
            }

            Console.WriteLine("[{0}]", string.Join(", ", numsArray));
        }

        private static void ProcessCommand(string[] commandTokens)
        {
            var offset = int.Parse(commandTokens[0]) % numsArray.Length;
            var operand = int.Parse(commandTokens[2]);

            switch (commandTokens[1].Trim())
            {
                case "&" :
                    AndCommand(offset, operand);
                    break;
                case "|" :
                    OrCommand(offset, operand);
                    break;
                case "^":
                    XorCommand(offset, operand);
                    break;
                case "+":
                    AddCommand(offset, operand);
                    break;
                case "-":
                    SubstractCommand(offset, operand);
                    break;
                case "*":
                    MultiplyCommand(offset, operand);
                    break;
                case "/":
                    DivideCommand(offset, operand);
                    break;                 
            }
        }

        private static void XorCommand(int offset, int operand)
        {
            GetIndex(offset);
            numsArray[currentIndex] ^= operand;
        }

        private static void OrCommand(int offset, int operand)
        {
            GetIndex(offset);
            numsArray[currentIndex] |= operand;
        }

        private static void AndCommand(int offset, int operand)
        {
            GetIndex(offset);
            numsArray[currentIndex] &= operand;
        }

        private static void DivideCommand(int offset, int operand)
        {
            GetIndex(offset);

            numsArray[currentIndex] /= operand;
        }

        private static void MultiplyCommand(int offset, int operand)
        {
            GetIndex(offset);

            numsArray[currentIndex] *= operand;
        }

        private static void SubstractCommand(int offset, int operand)
        {
            GetIndex(offset);

            numsArray[currentIndex] = numsArray[currentIndex] - operand < 0 ? 0 : numsArray[currentIndex] - operand;
        }

        private static void AddCommand(int offset, int operand)
        {
            GetIndex(offset);

            numsArray[currentIndex] += operand;
        }

        private static void GetIndex(int offset)
        {

            if (offset < 0)
            {
                offset += numsArray.Length;
            }

            currentIndex = (currentIndex + offset) % numsArray.Length;
        }
    }
}
