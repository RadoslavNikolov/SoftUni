namespace Kurtovo_Konare_Bank.UI
{
    using System;
    using Interfaces;

    public class ConsoleInputHandler : IInputHandler
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}