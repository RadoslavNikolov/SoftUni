namespace BangaloreUniversityLearningSystem
{
    using BangaloreUniversityLearningSystem.Core;
    using IO;

    public class Program
    {
        public static void Main()
        {
            var consoleReaderWriter = new ConsoleReaderWriter();
            var engine = new BangaloreUniversityEngine(consoleReaderWriter);
            engine.Run();
        }
    }
}