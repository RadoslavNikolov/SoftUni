using System;
using System.Linq;

class OddEvenProduct
{
    static void Main()
    {
        int oddProduct = 1;
        int evenProduct = 1;
        Console.Write("Input string with numbers: ");
        string inputStr = Console.ReadLine().Trim();
        int[] inputArr = inputStr.Split(' ').Select(int.Parse).ToArray();
        for (int i = 0; i < inputArr.Length; i++)
        {
            if (i % 2 == 0)
            {
                oddProduct *= inputArr[i];
            }
            else
            {
                evenProduct *= inputArr[i];
            }
        }

        if (oddProduct == evenProduct)
        {
            Console.WriteLine("Yes");
            Console.WriteLine("product = {0}", oddProduct);
        }
        else
        {
            Console.WriteLine("No");
            Console.WriteLine("odd_product = {0}", oddProduct);
            Console.WriteLine("even_product = {0}", evenProduct);
        }
    }
}
