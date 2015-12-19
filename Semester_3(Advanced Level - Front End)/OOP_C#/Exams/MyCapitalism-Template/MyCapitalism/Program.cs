using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCapitalism
{
    using Core;
    using Core.Factories;
    using Interfaces;
    using IO;

    class Program
    {
        static void Main(string[] args)
        {
            ICapitalismData data = new CapitalismData();
            IReaderWriter consoleReaderWriter = new ConsoleReadWriter();
            ICommandFactory commandFactory = new CommandFactory(data, consoleReaderWriter);
            ICommandManager commandManager = new CommandManager(commandFactory);
            

            IRunnable engine = new Engine(commandManager, consoleReaderWriter);
            engine.Run();

        }
    }
}
