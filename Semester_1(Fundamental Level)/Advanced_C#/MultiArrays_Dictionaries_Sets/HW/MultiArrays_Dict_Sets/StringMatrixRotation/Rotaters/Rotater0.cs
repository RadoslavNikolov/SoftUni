namespace StringMatrixRotation.Rotaters
{
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    public class Rotater0 : IRotater
    {
        public IList<IList<char>> Rotate(IList<string> inputStrings)
        {
            var processedArrays = new List<IList<char>>();

            foreach (var inputString in inputStrings)
            {
                processedArrays.Add(inputString.ToList());
            }

            return processedArrays;
        }
    }
}