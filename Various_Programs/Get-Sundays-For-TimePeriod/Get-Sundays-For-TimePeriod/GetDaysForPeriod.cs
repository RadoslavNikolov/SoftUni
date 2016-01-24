using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Get_Sundays_For_TimePeriod
{
    using System.Globalization;
    using System.IO;

    class GetDaysForPeriod
    {
        private static readonly CultureInfo CultInfo = new CultureInfo("bg-BG");
        static void Main(string[] args)
        {
            
            using (StreamWriter writer = new StreamWriter(@"Dates.txt"))
            {
                var year = 2015;
                var output = new StringBuilder();

                output.AppendLine(string.Format("Всички Съботи като дати(d-M-yyyy) за {0}г.", year));
                output.AppendLine(GetDatesForDayOfWeekInYear(year, DayOfWeek.Saturday));

                output.AppendLine(string.Format("Всички Недели като дати(d-M-yyyy) за {0}г.", year));
                output.AppendLine(GetDatesForDayOfWeekInYear(year, DayOfWeek.Sunday));

                try
                {
                    writer.WriteLine(output.ToString());
                }
                catch (Exception)
                {
                    
                    throw;
                }
            }

        }

        public static string GetDatesForDayOfWeekInYear(int year, DayOfWeek dayName)
        {
            var result = new StringBuilder();
            for (int month = 1; month <= 12; month++)
            {
                result.AppendLine(GetDatesForDayOfWeeakInMonth(year, month, dayName));
            }

            return result.ToString();
        }

        public static string GetDatesForDayOfWeeakInMonth(int year, int month, DayOfWeek dayName)
        {
            var result = new StringBuilder();
        
            for (int i = 1; i <= CultInfo.Calendar.GetDaysInMonth(year, month); i++)
            {
                if (new DateTime(year, month, i).DayOfWeek == dayName)

                    result.AppendLine(string.Format("{0}-{1}-{2}", i, month, year));
            }

            return result.ToString();
        }
    }
}
