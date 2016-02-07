namespace Blobs
{
    using Core;
    using Core.Factories;
    using Infrastructure;
    using IO;

    class BlobProgram
    {
        static void Main()
        {
            IBlobsData data = new BlobsData();
            IReaderWriter consoleReaderWriter = new ConsoleReadWriter();
            IBehaviorFactory behaviorFactory = new BehaviorFactory();
            IAttackFactory attackFactory = new AttackFactory();
            IUnitFactory unitFactory = new UnitFactory(behaviorFactory, attackFactory);
            ICommandFactory commandFactory = new CommandFactory(data, unitFactory);    
            ICommandManager commandManager = new CommandManager(commandFactory);

            IRunnable engine = new Engine(commandManager, consoleReaderWriter);
            engine.Run();
        }
    }
}
