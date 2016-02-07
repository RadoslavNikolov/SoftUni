namespace MyCapitalism.Interfaces
{
    using System.Collections.Generic;

    public interface ICommand
    {
        IEnumerable<string> Parameters { get; set; }

        void Execute();
    }
}