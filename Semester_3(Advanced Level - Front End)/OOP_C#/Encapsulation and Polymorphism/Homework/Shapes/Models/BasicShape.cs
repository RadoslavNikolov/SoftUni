namespace Shapes.Models
{
    using System;
    using Interfaces;

    public abstract class BasicShape : IShape
    {
        private double width;
        private double height;

        protected BasicShape(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get { return this.width; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Width cannot be negative");
                }
                this.width = value;
            }
        }

        public double Height
        {
            get { return this.height; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Height cannot be negative");
                }

                this.height = value;
            }
        }

        public abstract double CalculateArea();

        public abstract double CalculatePerimeter();

    }
}