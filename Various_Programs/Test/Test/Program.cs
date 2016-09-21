using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

namespace Test
{
    using System.Diagnostics;

    class Program
    {
        static TraceSource ts = new TraceSource("TraceSourceApp", SourceLevels.ActivityTracing);
        static void Main(string[] args)
        {
            decimal[] loanAmounts = {303m, 1000m, 85579m, 501.51m, 603m, 1200m, 400m, 22m};
            IEnumerable<decimal> loanQuery = from amount in loanAmounts
                where amount%2 == 0
                orderby amount ascending
                select amount;

            foreach (var am in loanQuery)
            {
                Console.WriteLine(am);
            }
        }

        static void DoWork()
        {
            var originalId = Trace.CorrelationManager.ActivityId;

            try
            {
                var guid = Guid.NewGuid();
                ts.TraceTransfer(1, "Changing activity", guid);

                Trace.CorrelationManager.ActivityId = guid;

                ts.TraceEvent(TraceEventType.Start, 0, "Start");
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                ts.TraceTransfer(1, "Changing Activity", originalId);
                ts.TraceEvent(TraceEventType.Stop, 0, "Stop");
                ts.Close();
            }
        }
    }

}
