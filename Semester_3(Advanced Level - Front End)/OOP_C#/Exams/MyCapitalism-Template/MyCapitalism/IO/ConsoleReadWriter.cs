namespace MyCapitalism.IO
{
    using System;
    using Interfaces;

    public class ConsoleReadWriter :IReaderWriter
    {
        public string Read()
        {
            var inputLine = Console.ReadLine();

            return inputLine;
        }

        public void Print(string message)
        {
            Console.WriteLine(message);
        }
    }
}