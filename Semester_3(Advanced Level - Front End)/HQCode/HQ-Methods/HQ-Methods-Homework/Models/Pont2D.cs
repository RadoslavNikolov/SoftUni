namespace Methods.Models
{
    public class Pont2D
    {
        public Pont2D(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public double X { get; private set; }

        public double Y { get; private set; }
    }
}