namespace Blobs.Infrastructure
{
    public interface ICommandManager
    {
        string ExecuteCommand(string commandLine);
    }
}