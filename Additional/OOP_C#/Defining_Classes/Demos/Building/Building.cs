
using System;

namespace Building
{
    public class Building
    {
        private string address;
        private int floors;
        private double sizeInSquareMeters;

        public string Address
        {
            get { return this.address; }
            private set { this.address = value; }
        }

        public int Floors
        {
            get { return this.floors; }
            set { this.floors = value; }
        }

        public double SizeInSquareMeters
        {
            get { return this.sizeInSquareMeters; }
            private set { this.sizeInSquareMeters = value; }
        }


        public Building(string address, int floors, double sizeInSquareMeters)
        {
            this.Address = address;
            this.Floors = floors;
            this.SizeInSquareMeters = sizeInSquareMeters;
        }

        public override string ToString()
        {
            return String.Format("Address: {0}; Floors: {1}; Size: {2} sq.m2",
                this.Address,
                this.Floors,
                this.SizeInSquareMeters);
        }
        
    }

    public class PlayWithBuildigs
    {
        static void Main()
        {
            Building softUni = new Building(
                    "15-17 Tintyava",
                    3,
                    1450.20);
            Building parkHotelMoskow = new Building(
                "10 zh.k. Iztok",
                18,
                12250.99);
            Console.WriteLine(softUni);
            Console.WriteLine(parkHotelMoskow);
          

            softUni.Floors = 20;
            Console.WriteLine(softUni);
        }
    }
}
