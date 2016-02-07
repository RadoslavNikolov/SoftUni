namespace TravelAgency.Interfaces
{
    public interface ICommandFactory
    {
        ICommand CreateCommand(string commandLine);
    }
}