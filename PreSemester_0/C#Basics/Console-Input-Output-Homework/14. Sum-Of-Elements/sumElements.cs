using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.Sum_Of_Elements
{
    class sumElements
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine().Trim();
            string[] numArr = number.Split(' ');
            int max = int.MinValue;
            int index=new int();
            int sum=new int();

            for (int i = 0; i < numArr.Length; i++)
			{
			    if (Convert.ToInt32(numArr[i])>max)
                {
                    max = Convert.ToInt32(numArr[i]);
                    index = i;
                }
			}

            for (int i = 0; i < numArr.Length; i++)
            {
                if (i!=index)
                {
                    sum += Convert.ToInt32(numArr[i]);
                }
            }

            if (max==sum)
            {
                Console.WriteLine("Yes, sum={0}",sum);
            }
            else
            {
                Console.WriteLine("No, diff={0}", Math.Abs(sum-max));
            }
        }
    }
}
