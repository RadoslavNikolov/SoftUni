namespace MassEffect.Engine
{
    using Commands;

    public class ExtendedCommandMenager : CommandManager
    {
        public override void SeedCommands()
        {
            base.SeedCommands();
            this.commandsByName["system-report"] = new SystemReportCommand(this.Engine);
        }
    }
}