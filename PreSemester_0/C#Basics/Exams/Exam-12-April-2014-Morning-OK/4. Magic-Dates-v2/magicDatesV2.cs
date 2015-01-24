using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Magic_Dates_v2
{
    class magicDatesV2
    {
        static void Main(string[] args)
        {
            int startYear = int.Parse(Console.ReadLine());
            int endYear = int.Parse(Console.ReadLine());
            int magicWeight = int.Parse(Console.ReadLine());
            int count=0;

            DateTime startDate=new DateTime(startYear,1,1);
            DateTime endDate = new DateTime(endYear,12,31);

            while (startDate<=endDate)
            {
                int dateWeight = 0;
                string strDate = startDate.ToString("ddMMyyyy");

                for (int i = 0; i < strDate.Length; i++)
                {
                    for (int j = i+1; j < strDate.Length; j++)
                    {
                        dateWeight += (int)char.GetNumericValue(strDate[i]) * (int)char.GetNumericValue(strDate[j]);
                    }
                }
                if (dateWeight==magicWeight)
                {
                    Console.WriteLine("{0}-{1}-{2}", startDate.Day.ToString().PadLeft(2,'0'), 
                                                     startDate.Month.ToString().PadLeft(2,'0'), startDate.Year);
                    count++;
                }
                startDate = startDate.AddDays(1);
            }

            if (count==0)
            {
                Console.WriteLine("No");
            }
        }
    }
}
