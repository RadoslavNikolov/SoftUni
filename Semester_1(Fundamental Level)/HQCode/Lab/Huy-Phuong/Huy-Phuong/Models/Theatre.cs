namespace Huy_Phuong.Models
{
    using System;
    using System.Collections.Generic;
    using Infrastructure;

    public class Theatre : ITheatre
    {
        private string name;
        private readonly IList<IPerformance> performances;

        public Theatre(string name)
        {
            this.Name = name;
            this.performances = new List<IPerformance>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Theater name cannot be null or empty");
                }
                this.name = value;
            }
        }

        public IEnumerable<IPerformance> Performances
        {
            get { return this.performances; }
        }

        public void AddPerformance(IPerformance performance)
        {
            this.performances.Add(performance);
        }

        public override string ToString()
        {
            var output = string.Join(", ", this.Performances);

            return output;
        }
    }
}