namespace StringMatrixRotation.Rotaters
{
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    public class Rotater270 : IRotater
    {
        public IList<IList<char>> Rotate(IList<string> inputStrings)
        {
            var maxLength = inputStrings.Max(x => x.Length);
            var reversedInputList = new List<List<char>>();

            foreach (var inputString in inputStrings)
            {
                var tempList = inputString.PadRight(maxLength, ' ').ToList();
                tempList.Reverse();
                reversedInputList.Add(tempList);
            }
            
            var processedArrays = new List<IList<char>>();

            for (int i = 0; i < maxLength; i++)
            {
                List<char> newCharList = new List<char>();

                for (int j = 0; j < reversedInputList.Count; j++)
                {
                    if (i < reversedInputList[j].Count)
                    {
                        newCharList.Add(reversedInputList[j][i]);
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