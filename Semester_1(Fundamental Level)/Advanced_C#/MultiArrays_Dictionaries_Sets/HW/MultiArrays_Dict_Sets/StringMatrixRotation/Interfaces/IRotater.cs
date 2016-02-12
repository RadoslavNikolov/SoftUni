namespace StringMatrixRotation.Interfaces
{
    using System.Collections.Generic;

    public interface IRotater
    {
        IList<IList<char>> Rotate(IList<string> inputStrings);
    }
}