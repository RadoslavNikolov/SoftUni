namespace Kurtovo_Konare_Bank.UI
{
    using System;
    using Interfaces;

    public class ConsoleRenderer : IRender
    {
        public void WriteLine(string toPrint)
        {
            Console.WriteLine(toPrint);
        }
    }
}