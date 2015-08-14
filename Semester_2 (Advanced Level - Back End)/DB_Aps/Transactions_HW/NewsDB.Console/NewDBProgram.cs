using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsDB.Console
{
    using Data;
    using Console = System.Console;

    public class NewDBProgram
    {
        static void Main()
        {
            var context = new NewsDBContext();

            //Problem 2 - Concurrent Updates (Console App)
            ParalelUpdates.MakeParalelUpdate();



        }
       
    }
}
