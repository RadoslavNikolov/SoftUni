namespace Galactic_GPS
{
    using System;
    using System.Globalization;

    public struct Location
    {
        private double latitude;
        private double longitude;

        public Location(double latitude, double longitude, Planet planet) : this()
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Planet = planet;
        }

        public double Latitude
        {
            get { return this.latitude; }
            set
            {
                if (value < -90 && value > 90)
                {
                    throw new ArgumentOutOfRangeException("value", "Latitude must be in range[-90.0 -- +90.0]");
                }
                this.latitude = value;
            }
        }

        public double Longitude
        {
            get { return this.longitude; }
            set
            {
                if (value < -190 && value > 180)
                {
                    throw new ArgumentOutOfRangeException("value", "Longitude must be in range[-90.0 -- +90.0]");
                }
                this.longitude = value;
            }
        }

        public Planet Planet { get; set; }

        public override string ToString()
        {
            return string.Format("{0:F6}, {1:F6} - {2}", this.Latitude, this.Longitude, this.Planet);
        }
    }
}