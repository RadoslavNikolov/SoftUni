namespace Kurtovo_Konare_Bank
{
    using Engine;
    using UI;

    class BankProgram
    {
        static void Main()
        {
            BankEngine engine = new BankEngine(new ConsoleRenderer(), new ConsoleInputHandler());
            engine.Run();
        }
    }
}
