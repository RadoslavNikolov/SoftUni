using System;

class MinMaxSum
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int sum=0;
        int minNum=int.MaxValue;
        int maxNum=int.MinValue;
        for (int i = 0; i < n; i++)
        {
            int num=int.Parse(Console.ReadLine());
            minNum = Math.Min(minNum, num);
            maxNum = Math.Max(maxNum,num);
            sum += num;
        }
        Console.WriteLine("min = {0}", minNum);
        Console.WriteLine("max = {0}", maxNum);
        Console.WriteLine("sum = {0}", sum);
        Console.WriteLine("avg = {0:F2}", sum/(double)n);
    }
}
