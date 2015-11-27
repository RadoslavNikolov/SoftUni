namespace Shapes.Models
{
    using System;
    using Interfaces;

    public class Circle : IShape
    {
        private double radius;

        public Circle(double radius, Point center)
        {
            this.Radius = radius;
            this.Center = center;
        }

        public Point Center { get; private set; }

        public double Radius
        {
            get { return this.radius; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Radius cannot be negative");
                }
                this.radius = value;
            }
        }

        public double CalculateArea()
        {
            return Math.PI*this.Radius*this.Radius;
        }

        public double CalculatePerimeter()
        {
            return 2*this.Radius*Math.PI;
        }
    }
}