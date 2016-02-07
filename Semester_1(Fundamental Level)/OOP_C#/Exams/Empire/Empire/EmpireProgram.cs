using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empire
{
    using Core;
    using Core.Factories;
    using IO;

    class EmpireProgram
    {
        static void Main(string[] args)
        {

            var factory = new Factory();
            var reader = new ConsoleReader();
            var writer = new ConsoleWriter();
            var data = new EmpireData();

            var engine = new Engine(factory, data, reader, writer);
            engine.Run();
        }
    }
}
