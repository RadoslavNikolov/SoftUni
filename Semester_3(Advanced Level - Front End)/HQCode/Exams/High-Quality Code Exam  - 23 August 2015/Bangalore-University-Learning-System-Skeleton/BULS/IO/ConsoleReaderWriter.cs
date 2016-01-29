namespace BangaloreUniversityLearningSystem.IO
{
    using System;
    using Interfaces;

    public class ConsoleReaderWriter : IReaderWriter
    {
        public string Read()
        {
            var result = Console.ReadLine();

            return result;
        }

        public void Write(string messsage)
        {
            Console.WriteLine(messsage);
        }
    }
}