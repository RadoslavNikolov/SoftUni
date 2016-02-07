namespace MyCapitalism.Interfaces
{
    public interface ICommandFactory
    {
        ICommand CreateCommand(string commandLine);
    }
}