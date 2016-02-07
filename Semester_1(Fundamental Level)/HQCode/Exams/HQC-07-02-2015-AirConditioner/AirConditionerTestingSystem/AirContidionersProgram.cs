namespace AirConditionerTestingSystem
{
    using System.Globalization;
    using System.Threading;
    using Core;
    using Core.Factories;
    using Data;
    using Interfaces;
    using UI;

    public class AirContidionersProgram
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            ////DI: Ioc example. This way we can moq everithing we want
            IConditionerDataBase conditionerData = new ConditionerDataBase();
            IUserInterface userInterface = new ConsoleUserInterface();
            IConditionerController bussinesCatalog = new ConditionerController(conditionerData);
            ICommandFactory commandFactory = new CommandFactory(bussinesCatalog);
            ICommandManager commandManager = new CommandManager(commandFactory);

            IRunnable engine = new Engine(commandManager, userInterface);
            engine.Run();
        }
    }
}
