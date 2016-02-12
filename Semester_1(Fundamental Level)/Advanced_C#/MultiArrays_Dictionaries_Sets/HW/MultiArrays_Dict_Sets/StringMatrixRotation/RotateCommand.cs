namespace StringMatrixRotation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Interfaces;

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
}