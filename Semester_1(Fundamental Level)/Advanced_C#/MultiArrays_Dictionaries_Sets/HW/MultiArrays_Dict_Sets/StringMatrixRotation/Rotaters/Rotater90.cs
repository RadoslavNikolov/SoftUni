namespace StringMatrixRotation.Rotaters
{
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    public class Rotater90 : IRotater
    {
        public IList<IList<char>> Rotate(IList<string> inputStrings)
        {
            var maxLength = inputStrings.Max(x => x.Length);
            var processedArrays = new List<IList<char>>();

            for (int i = 0; i < maxLength; i++)
            {
                List<char> newCharList = new List<char>();

                for (int j = inputStrings.Count-1; j >= 0; j--)
                {
                    if (i < inputStrings[j].Length)
                    {
                        newCharList.Add(inputStrings[j][i]);
                    }
                    else
                    {
                        newCharList.Add(' ');
                    }
                }

                processedArrays.Add(newCharList);
            }

            return processedArrays;
        }
    }
}