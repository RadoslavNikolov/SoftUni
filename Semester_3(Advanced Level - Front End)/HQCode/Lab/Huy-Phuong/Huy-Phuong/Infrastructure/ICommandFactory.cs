namespace Huy_Phuong.Infrastructure
{
    public interface ICommandFactory
    {
        ICommand CreateCommand(string commandLine);
    }
}