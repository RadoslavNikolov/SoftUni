using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeIntervals
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var dt = SplitTimeInIntervals(new TimeSpan(6,0,0), new TimeSpan(9,0,0));

        }

        private DataTable SplitTimeInIntervals(TimeSpan start, TimeSpan end)
        {
            var startDate = DateTime.Now.Date + start;
            var endDate = DateTime.Now.Date + end;
            int minutesInterval = 15;

            var intervals = Enumerable.Range(start.Hours, (end.Hours - start.Hours))
                .Select(i => Enumerable.Range(0, 60/ minutesInterval).Select(x => Tuple.Create(
                     Max((startDate.Date + new TimeSpan(i, x * minutesInterval, 0)), startDate),
                     Min((startDate.Date + new TimeSpan(i, x * minutesInterval, 0)).AddMinutes(minutesInterval), endDate)
                    )))
                    .SelectMany(i => i.Select( x => new Tuple<TimeSpan, TimeSpan>(x.Item1.TimeOfDay,
                            x.Item2.TimeOfDay))).ToList();



            var intervals1 = Enumerable.Range(start.Hours, (end.Hours - start.Hours))
                .Select(i => Enumerable.Range(0, 60 / minutesInterval).Select(x => Tuple.Create(
                      Max((startDate.Date + new TimeSpan(i, x * minutesInterval, 0)), startDate),
                      Min((startDate.Date + new TimeSpan(i, x * minutesInterval, 0)).AddMinutes(minutesInterval), endDate)
                     )))
                    .SelectMany(i => i.Select(x => new Tuple<TimeSpan, TimeSpan>(x.Item1.TimeOfDay,
                           x.Item2.TimeOfDay))).ToList();

            return new DataTable();
        }

        private DateTime Min(DateTime a, DateTime b)
        {
            if (a > b)
            {
                return b;
            }

            return a;
        }

        private DateTime Max(DateTime a, DateTime b)
        {
            if (a<=b)
            {
                return b;
            }

            return a;
        }

    }
}
