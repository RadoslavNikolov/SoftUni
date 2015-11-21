namespace SULS.Models
{
    using System;
    using System.Collections.Generic;

    public class Visit
    {
        public Visit(DateTime visitOn)
        {
            this.VisitOn = visitOn;
        }

        public DateTime VisitOn { get; set; }

        public override string ToString()
        {
            return $"Visited lection on: {this.VisitOn}\n";
        }
    }
}