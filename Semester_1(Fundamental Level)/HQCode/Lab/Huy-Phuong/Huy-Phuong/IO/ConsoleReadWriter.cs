namespace Huy_Phuong.IO
{
    using System;
    using Infrastructure;
    public class ConsoleReadWriter : IReaderWriter
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