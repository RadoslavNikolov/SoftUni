namespace MyCapitalism.Interfaces
{
    using System.Collections.Generic;

    public interface ICommand
    {
        IList<string> Parameters { get; set; }

        string Execute();
    }
}