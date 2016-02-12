namespace StringMatrixRotation.Rotaters
{
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    public class Rotater180 : IRotater
    {
        public IList<IList<char>> Rotate(IList<string> inputStrings)
        {
            var maxLength = inputStrings.Max(x => x.Length);
            var processedArrays = new List<IList<char>>();

            for (int i = inputStrings.Count - 1; i >= 0; i--)
            {
                var newCharList = inputStrings[i].PadRight(maxLength, ' ').ToList();
                newCharList.Reverse();
                processedArrays.Add(newCharList);
            }

            return processedArrays;
        }
    }
}