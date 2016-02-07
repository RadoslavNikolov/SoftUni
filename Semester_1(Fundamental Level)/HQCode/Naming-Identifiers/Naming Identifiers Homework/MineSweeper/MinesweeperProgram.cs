namespace Minesweeper
{
    using System;
    using System.Collections.Generic;
    using Core;
    using Intefaces;
    using IO;

    public class Minesweeper
    {
        public static void Main()
        {
            IReaderWriter readerWriter = new ConsoleReaderWriter();
            var engine = new Engine(readerWriter);

            engine.Run();
        }
    }
}