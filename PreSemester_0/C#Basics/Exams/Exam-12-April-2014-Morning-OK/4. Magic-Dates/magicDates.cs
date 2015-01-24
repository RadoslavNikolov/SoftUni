using System;
using System.Collections.Concurrent;

class magicDates
{
    static void Main()
    {
        int startYear = int.Parse(Console.ReadLine());
        int endYear = int.Parse(Console.ReadLine());
        int magicWeight = int.Parse(Console.ReadLine());
        int count = 0;

        for (int i = startYear; i <= endYear; i++)
        {
            bool leapYear=((i % 4==0 && i % 100!=0) || (i % 4==0 && i % 100==0 && i % 400==0));
            for (int j = 1; j <= 12; j++)
            {
                switch (j)
                {
                    case 1: count=checkDate(i, j, 31,magicWeight,count); break;
                    case 2: 
                        if (leapYear==true)
	                    {
		                    count=checkDate(i,j,29,magicWeight,count);
                        }
                        else
                        {
                            count=checkDate(i, j, 28, magicWeight,count);
                        }
                        break;
                    case 3: count=checkDate(i, j, 31,magicWeight,count); break;
                    case 4: count=checkDate(i, j, 30,magicWeight,count); break;
                    case 5: count=checkDate(i, j, 31,magicWeight,count); break;
                    case 6: count=checkDate(i, j, 30, magicWeight,count); break;
                    case 7: count=checkDate(i, j, 31, magicWeight,count); break;
                    case 8: count=checkDate(i, j, 31, magicWeight,count); break;
                    case 9: count=checkDate(i, j, 30, magicWeight,count); break;
                    case 10: count=checkDate(i, j, 31, magicWeight,count); break;
                    case 11: count=checkDate(i, j, 30, magicWeight,count); break;
                    case 12: count=checkDate(i, j, 31, magicWeight,count); break;
                    default:
                        break;
                }
            }
        }
        if (count==0)
        {
            Console.WriteLine("No");
        }
    }

   
    static int checkDate(int year,int month, int days, int megicWeight, int count)
    {
        for (int i = 1; i <= days; i++)
        {
            int weight = 0;
            string str = "" + i.ToString().PadLeft(2,'0') + month.ToString().PadLeft(2,'0') + year.ToString().PadLeft(4,'0');
            for (int j = 0; j < str.Length; j++)
            {
                for (int g = j+1; g < str.Length; g++)
                {
                    weight +=(int)char.GetNumericValue(str[j]) *(int)char.GetNumericValue(str[g]);
                }
            }
            if (weight == megicWeight)
            {
                Console.WriteLine("{0}-{1}-{2}", i.ToString().PadLeft(2, '0'), month.ToString().PadLeft(2, '0'), year);
                count++;
            }
        }
        return count;
    }
}
