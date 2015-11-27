﻿namespace Battleships.Ships
{
    using System;

    public abstract class Ship
    {
        private string name;
        private double lengthInMeters;
        private double volume;

        protected Ship(string name, double lengthInMeters, double volume)
        {
            this.name = name;
            this.lengthInMeters = lengthInMeters;
            this.volume = volume;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value", "Name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public double LengthInMeters
        {
            get
            {
                return this.lengthInMeters;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "The length of a ship cannot be negative.");
                }

                this.lengthInMeters = value;
            }
        }

        public double Volume
        {
            get
            {
                return this.volume;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "The volume of a ship cannot be negative.");
                }

                this.volume = value;
            }
        }

        public bool IsDestroyed { get; set; }
    }
}
