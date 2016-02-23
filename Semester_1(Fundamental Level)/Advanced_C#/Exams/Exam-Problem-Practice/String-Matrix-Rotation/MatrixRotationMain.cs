namespace String_Matrix_Rotation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class MatrixRotationMain
    {
        private static IRotateCommand rotateCommand;

        public static void Main()
        {
            while (true)
            {
                string inputLine = Console.ReadLine();


                if (inputLine.Contains("Rotate"))
                {
                    
                    int degrees = int.Parse(inputLine.Trim().Split('(').Last().Replace(")", string.Empty).Trim());

                    rotateCommand = new RotateCommand(degrees);
                    continue;
                }

                if (inputLine.ToLower().Equals("end") && rotateCommand != null)
                {
                    rotateCommand.DoRotation();
                    Console.WriteLine(rotateCommand.ToString());
                    Environment.Exit(0);
                }

                if (rotateCommand != null)
                {
                    rotateCommand.AddString(inputLine);
                }
            }
        }
    }


    public class RotateCommand : IRotateCommand
    {
        private readonly IList<string> inputStrings = new List<string>();
        private IList<IList<char>> processedArrays = new List<IList<char>>();
        private readonly IRotaterFactory rotaterFactory;
        private readonly IRotater rotater;
        private readonly int rotationDegrees;

        public RotateCommand(int rotationDegrees)
        {
            this.rotationDegrees = rotationDegrees;
            this.rotaterFactory = new RotaterFactory();
            this.rotater = this.rotaterFactory.GetRotater(this.rotationDegrees);
        }

        public RotateCommand(int rotationDegrees, IRotaterFactory rotaterFactory)
            : this(rotationDegrees)
        {
            this.rotaterFactory = rotaterFactory;
        }

        public void AddString(string input)
        {
            this.inputStrings.Add(input);
        }

        public void DoRotation()
        {
            this.processedArrays = this.rotater.Rotate(this.inputStrings);
        }

        public override string ToString()
        {
            var output = new StringBuilder();

            foreach (var array in this.processedArrays)
            {
                output.AppendLine(string.Join("", array));
            }

            return output.ToString();
        }
    }

    public class RotaterFactory : IRotaterFactory
    {
        public IRotater GetRotater(int degrees)
        {
            IRotater rotater = null;
            switch (degrees % 360)
            {
                case 90:
                    rotater = new Rotater90();
                    break;

                case 180:
                    rotater = new Rotater180();
                    break;

                case 270:
                    rotater = new Rotater270();
                    break;
                default:
                    rotater = new Rotater0();
                    break;
            }

            return rotater;
        }
    }

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

    public class Rotater90 : IRotater
    {
        public IList<IList<char>> Rotate(IList<string> inputStrings)
        {
            var maxLength = inputStrings.Max(x => x.Length);
            var processedArrays = new List<IList<char>>();

            for (int i = 0; i < maxLength; i++)
            {
                List<char> newCharList = new List<char>();

                for (int j = inputStrings.Count - 1; j >= 0; j--)
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

    public interface IRotateCommand
    {
        void AddString(string input);

        void DoRotation();
    }


    public interface IRotater
    {
        IList<IList<char>> Rotate(IList<string> inputStrings);
    }

    public interface IRotaterFactory
    {
        IRotater GetRotater(int degrees);
    }
}
