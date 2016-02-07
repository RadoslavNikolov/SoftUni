namespace Minesweeper.Models
{
    using System;
    using Intefaces;

    public class Player : IPlayer
    {
        private string name;
        private int points;

        public Player(string name, int points = 0)
        {
            this.Name = name;
            this.Points = points;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Player name cannot be null or empty");
                }

                this.name = value;
            }
        }

        public int Points
        {
            get { return this.points; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Pints cannot be negative");
                }

                this.points = value;
            }
        }

        public override string ToString()
        {
            var output = string.Format("{0} --> {1} boxes", this.Name, this.Points);

            return output;
        }
    }
}