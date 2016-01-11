namespace Blobs.Infrastructure
{
    /// <summary>
    /// Interface for factory classes capable of creating commands
    /// </summary>
    public interface ICommandFactory
    {
        /// <summary>
        /// Create instance of command class from given command input line
        /// </summary>
        /// <param name="commandLine">Given input line as <see cref="System.String"/></param>
        /// <returns>Instance of command class as interface <see cref="Blobs.Infrastructure.Command"/></returns>
        ICommand CreateCommand(string commandLine);
    }
}