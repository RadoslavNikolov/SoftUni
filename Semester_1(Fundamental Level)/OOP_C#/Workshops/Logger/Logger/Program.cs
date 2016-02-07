using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    class Program
    {
        static void Main()
        {
            var logger = new Logger();
            logger.Info("My first test");
            logger.Fatal("Lellllleeeeeeeeeeeeee");
        }
    }
}
