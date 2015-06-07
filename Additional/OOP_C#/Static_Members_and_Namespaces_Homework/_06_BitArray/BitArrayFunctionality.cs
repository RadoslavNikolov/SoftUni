using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _06_BitArray
{
    using System;
    using System.Numerics;
    using System.Text.RegularExpressions;

    static class BitArrayFunctionality
    {
        public static BigInteger ConvertToDecimal(BitArray numberAsBitArray)
        {
            string binaryNumber = numberAsBitArray.ToString();
            BigInteger dec = 0;

            if (!Regex.IsMatch(binaryNumber, @"^[0-1]+$") || binaryNumber == "")  // using Regex.IsMatch to chech if input contains only '0' and '1'
            {
                throw new AggregateException("Invalid binary number!");
            }

            for (int i = 0; i < binaryNumber.Length; i++)
            {
                if (binaryNumber[binaryNumber.Length - i - 1] == '1')
                {
                    dec += (BigInteger)Math.Pow(2, i);
                }
            }

            return dec;
        }

        public static string ConvertToHexadecimal(BitArray numberAsBitArray)
        {
            BigInteger number = BitArrayFunctionality.ConvertToDecimal(numberAsBitArray);
            BigInteger devider = 0;
            int remainder = 0;
            List<string> outputList = new List<string>();

            do
            {
                devider = number / 16;
                remainder = (int)(number % 16);
                number = devider;
                switch (remainder)
                {
                    case 10: outputList.Insert(0, "A"); break;
                    case 11: outputList.Insert(0, "B"); break;
                    case 12: outputList.Insert(0, "C"); break;
                    case 13: outputList.Insert(0, "D"); break;
                    case 14: outputList.Insert(0, "E"); break;
                    case 15: outputList.Insert(0, "F"); break;
                    default:
                        outputList.Insert(0, Convert.ToString(remainder));
                        break;
                }
            } while (devider != 0);

            StringBuilder result = new StringBuilder();
            foreach (string item in outputList)
            {
                result.Append(item);
            }
            return result.ToString();

        }
    }
}
