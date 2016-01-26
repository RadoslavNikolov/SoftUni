namespace Huy_Phuong.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Custom_Exceptions;
    using Infrastructure;
    using Models;

    public class TheatreData : ITheatreData
    {
        private readonly IList<ITheatre> theatres;

        public TheatreData()
        {
            this.theatres = new List<ITheatre>();
        }

        public IEnumerable<ITheatre> Theatres
        {
            get { return this.theatres; }
        }

        private ITheatre GetTheatreByName(string theatreName)
        {
            var theatre = this.Theatres.FirstOrDefault(t => String.Equals(t.Name, theatreName, StringComparison.CurrentCultureIgnoreCase));

            return theatre;
        }

        public void AddTheatre(string theatreName)
        {
            var theatre = this.GetTheatreByName(theatreName);

            if (theatre != null)
            {
                throw new DuplicateTheatreException("Error: Duplicate theatre");
            }

            var newTheatre = new Theatre(theatreName);
            this.theatres.Add(newTheatre);
        }

        public IEnumerable<string> ListTheatres()
        {
            var allTheatres = this.Theatres.OrderBy(t => t.Name).Select(t => t.Name);

            return allTheatres;
        }

        public void AddPerformance(string theatreName, string performanceTitle, DateTime startDateTime, TimeSpan duration, decimal price)
        {
            var theatre = this.GetTheatreByName(theatreName);

            if (theatre == null)
            {
                throw new TheatreNotFoundException("Error: Theatre does not exist");
            }

            var newPerformance = new Performance(theatre, performanceTitle, startDateTime, duration, price );
            Helpers.Validators.ValidatePerformances.ValidateForOverlap(theatre, newPerformance);

            theatre.AddPerformance(newPerformance);      
        }

        public IEnumerable<IPerformance> ListAllPerformances()
        {
            var performances = new List<IPerformance>();

            this.theatres.ToList().ForEach(t =>
                {
                    performances.AddRange(t.Performances);
                });

            return performances
                .OrderBy(p => p.Theatre.Name)
                .ThenBy(p => p.StartTime);
        }

        public IEnumerable<IPerformance> ListPerformances(string theatreName)
        {
            var theatre = this.GetTheatreByName(theatreName);

            if (theatre == null)
            {
                throw new TheatreNotFoundException("Error: Theatre does not exist");
            }

            return theatre.Performances;
        }
    }
}