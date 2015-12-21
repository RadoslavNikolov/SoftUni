namespace Blobs.Infrastructure
{
    public interface ICommandFactory
    {
        ICommand CreateCommand(string commandLine);
    }
}