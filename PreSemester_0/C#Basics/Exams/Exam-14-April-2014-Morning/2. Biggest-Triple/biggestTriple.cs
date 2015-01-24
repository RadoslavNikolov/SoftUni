using System;
using System.Linq;
using System.Collections.Generic;

class biggestTriple
{
    static void Main()
    {
        string input = Console.ReadLine().Trim();
        string[] strNum = input.Split(' ');
        int[] numbers = strNum.Select(int.Parse).ToArray();
        int index = 0;
        int maxSum = Int32.MinValue;
        int start = 0;

        while (index < numbers.Length)
        {
            int num1 = numbers[index];
            int num2 = 0;
            if (index + 1 < numbers.Length)
            {
                num2 = numbers[index + 1];
            }
            int num3 = 0;
            if (index + 2 < numbers.Length)
            {
                num3 = numbers[index + 2];
            }
            int sum = num1 + num2 + num3;
            if (sum > maxSum)
            {
                maxSum = sum;
                start = index;
            }
            index = index + 3;
        }
        if (numbers.Length-start>2)
        {
            for (int i = 0; i < 3; i++)
            {
                Console.Write("{0} ",numbers[start]);
                start++;
            }
        }
        else if (numbers.Length-start==2)
        {
            for (int i = 0; i < 2; i++)
            {
                Console.Write("{0} ",numbers[start]);
                start++;
            }
        }
        else
        {
            Console.WriteLine(numbers[start]);
        }

        //while (maxSum != 0)
        //{
        //    Console.Write(numbers[start]);
        //    maxSum = maxSum - numbers[start];
        //    start++;
        //    if (maxSum != 0)
        //    {
        //        Console.Write(" ");
        //    }
        //}
        //Console.WriteLine();



        //int currentElement = 0;
        //int nextTriple = currentElement + 3;
        //int count = 0;
        //int bigesSum = 0;
        //string tempStr = "";
        //int tempSum = 0;
        //List<string> output = new List<string>();
        //for (int i = 0; i < number.Length; i++)
        //{           
        //    if (currentElement<=nextTriple-1 && currentElement<number.Length-1)
        //    {
        //        tempSum += number[i];
        //        tempStr = tempStr + " " + number[i];
        //        currentElement++;
        //    }
        //    else if(currentElement<number.Length-1)
        //    {
        //        tempStr=tempStr.Trim(' ', '+');
        //        output.Add(tempStr);
        //        if (tempSum==bigesSum)
        //        {
        //            bigesSum = tempSum;
        //        }
        //        else if (tempSum==bigesSum)
        //        {
        //            bigesSum = tempSum;
        //            count++;
        //        }
        //        tempSum = 0;
        //        tempStr = "";
        //        nextTriple += 3;
        //        tempSum += number[i];
        //        tempStr = tempStr + " " + number[i];
        //        currentElement++;
        //    }
        //    else if (currentElement==number.Length-1)
        //    {
        //        tempSum += number[i];
        //        tempStr = tempStr + " " + number[i];
        //        tempStr=tempStr.Trim(' ', '+');
        //        output.Add(tempStr);
        //        if (tempSum>bigesSum)
        //        {
        //            bigesSum = tempSum;
        //            //count++;
        //        }
        //    }
        //}
        //Console.WriteLine(output[count]);
    }
}
