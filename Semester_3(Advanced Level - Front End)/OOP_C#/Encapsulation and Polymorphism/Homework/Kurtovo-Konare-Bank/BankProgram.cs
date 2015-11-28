namespace Kurtovo_Konare_Bank
{
    using Engine;
    using Models;
    using UI;

    class BankProgram
    {
        static void Main()
        {
            BankEngine engine = new BankEngine(new ConsoleRenderer(), new ConsoleInputHandler(), new AccountingLogic());
            engine.Run();
        }
    }
}
