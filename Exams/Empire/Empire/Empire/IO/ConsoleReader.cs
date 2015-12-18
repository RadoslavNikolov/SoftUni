namespace Empire.IO
{
    using System;
    using Interfaces;

    public class ConsoleReader : IInputReader
    {

        public string Read()
        {
            var inputLine = Console.ReadLine();

            return inputLine;
        }
    }
}