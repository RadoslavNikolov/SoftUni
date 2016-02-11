namespace ToTheStars.Models
{
    using Interfaces;
    public class Starship : IMovable
    {
        const string StartShipName = "Normandy";

        public Starship(Point2D coordinates)
        {
            this.Name = StartShipName;
            this.Coordinates = coordinates;
        }

        public string Name { get; set; }

        public Point2D Coordinates { get; set; }

        public void MoveUp()
        {
            this.Coordinates.Y++;
        }
    }
}