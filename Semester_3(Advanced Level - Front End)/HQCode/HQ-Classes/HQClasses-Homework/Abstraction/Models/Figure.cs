namespace Abstraction.Models
{
    using System;
    using Helpers;
    using Interfaces;

    abstract class Figure : IFigure
    {
        private double width;
        private double height;
        private double radius;

        protected Figure(double radius)
        {
            this.Radius = radius;
        }

        protected Figure(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get { return this.width; }
            private set
            {
                Validators.ValidateForNegativeNumber(value);
                this.width = value;
            }
        }      

        public double Height
        {
            get { return this.height; }
            private set
            {
                Validators.ValidateForNegativeNumber(value);
                this.height = value;
            }
        }

        public double Radius
        {
            get { return this.radius; }
            private set
            {
                Validators.ValidateForNegativeNumber(value);
                this.radius = value;
            }
        }

        public abstract double CalcPerimeter();

        public abstract double CalcSurface();

        public override string ToString()
        {
            var output = String.Format("I am a {0}. My perimeter is {1:f2}. My surface is {2:f2}.", this.GetType().Name, this.CalcPerimeter(), this.CalcSurface());

            return output;
        }
    }
}
