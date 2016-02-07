namespace Huy_Phuong.Models
{
    using System;
    using System.Globalization;
    using Custom_Exceptions;
    using Infrastructure;
    public class Performance : IPerformance
    {
        private ITheatre theatre;
        private string name;
        private DateTime startTime;
        private TimeSpan duration;
        private decimal ticketPrice;

        public Performance(ITheatre theatre,
            string name,
            DateTime startTime, 
            TimeSpan duration, 
            decimal ticketPrice)
        {
            this.Theatre = theatre;
            this.Name = name;
            this.StartTime = startTime;
            this.Duration = duration;
            this.TicketPrice = ticketPrice;
        }

        public ITheatre Theatre
        {
            get { return this.theatre; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value", "Theatre cannot be null");
                }
                this.theatre = value;
            }
        }

        public string Name
        {
            get { return this.name; }
            internal set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Performance name cannot be null or empty");
                }
                this.name = value;
            }
        }

        public DateTime StartTime
        {
            get { return this.startTime; }
            internal set
            {
                if (DateTime.Compare(value, DateTime.Now.AddYears(-20)) < 0)
                {
                    throw new IlegalStartDateException("Start date cannot be earlier than now");
                }
                this.startTime = value;
            }
        }

        public TimeSpan Duration
        {
            get { return this.duration; }
            internal set
            {
                if (value.TotalMinutes < 0)
                {
                    throw new ILegalDurationException("Performance duration cannot be negative");
                }
                this.duration = value;
            }
        }

        public decimal TicketPrice
        {
            get { return this.ticketPrice; }
            internal set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price cannot be negative");
                }
                this.ticketPrice = value;
            }
        }

        public string Print()
        {
            var output = string.Format("({0}, {1}, {2})",
                this.name,
                this.theatre.Name,
                this.startTime.ToString("dd.MM.yyyy hh:mm", CultureInfo.InvariantCulture));

            return output;          
        }

        public override string ToString()
        {
            var output = string.Format("({0}, {1})",
                this.name,
                this.startTime.ToString("dd.MM.yyyy hh:mm", CultureInfo.InvariantCulture));

            return output;
        }
    }
}