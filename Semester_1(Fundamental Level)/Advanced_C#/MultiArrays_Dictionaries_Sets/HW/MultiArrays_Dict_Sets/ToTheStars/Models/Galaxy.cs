namespace ToTheStars.Models
{
    using Interfaces;
    public class Galaxy : IGalaxy
    {
        const int GalaxySize = 1;

        public Galaxy(string galaxyName, Point2D coordinates)
        {
            this.GalaxyName = galaxyName;
            this.Coordinates = coordinates;
        }

        public string GalaxyName { get; private set; }

        public Point2D Coordinates { get; private set; }

        public bool IsIntersecting(Point2D starshipCoordinates)
        {
            var isIntersecting = false;

            if (this.Coordinates.X - GalaxySize <= starshipCoordinates.X && starshipCoordinates.X <= this.Coordinates.X + GalaxySize &&
                this.Coordinates.Y - GalaxySize <= starshipCoordinates.Y && starshipCoordinates.Y <= this.Coordinates.Y + GalaxySize)
            {
                isIntersecting = true;
            }
            return isIntersecting;
        }
    }
}