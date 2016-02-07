namespace Huy_Phuong.Core
{
    using System;
    using Infrastructure;
    public class Engine : IRunnable
    {
        private readonly ICommandManager commandManager;
        private readonly IReaderWriter readerWriter;

        public Engine(ICommandManager commandManager, IReaderWriter readerWriter)
        {
            this.commandManager = commandManager;
            this.readerWriter = readerWriter;
        }

        public void Run()
        {
            while (true)
            {
                string input = this.readerWriter.Read();

                if (string.IsNullOrWhiteSpace(input))
                {
                    continue;
                }

                try
                {
                    string output = this.commandManager.ExecuteCommand(input);

                    if (!string.IsNullOrWhiteSpace(output))
                    {
                        this.readerWriter.Print(output.Trim());

                    }
                }
                catch (Exception e)
                {
                    this.readerWriter.Print(e.Message);
                }
            }
        } 
    }
}