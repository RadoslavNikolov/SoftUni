namespace TravelAgency.IO
{
    using System;
    using Interfaces;

    public class ConsoleReaderWriter : IReaderWriter
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