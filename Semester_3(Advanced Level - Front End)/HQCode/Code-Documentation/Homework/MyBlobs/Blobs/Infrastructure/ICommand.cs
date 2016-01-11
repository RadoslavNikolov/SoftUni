namespace Blobs.Infrastructure
{
    using System.Collections.Generic;
    using System.Text;

    public interface ICommand
    {
        StringBuilder Output { get;}

        IList<string> Parameters { get;}

        string Execute();
    }
}