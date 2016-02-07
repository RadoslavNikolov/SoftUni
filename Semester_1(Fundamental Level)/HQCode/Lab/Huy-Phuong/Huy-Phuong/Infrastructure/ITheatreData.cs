namespace Huy_Phuong.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using Models;

    /// <summary>
    /// This interface is responsible for interaction with "DB"
    /// </summary>
    public interface ITheatreData
    {
        /// <summary>
        /// This simulates DataTable
        /// </summary>
        IEnumerable<ITheatre> Theatres { get; }

        /// <summary>
        /// This adds new <see cref="Huy_Phuong.Infrastructuren"/>
        /// </summary>
        /// <param name="theatreName">Theatre name</param>
        void AddTheatre(string theatreName);

        /// <summary>
        /// Returns list of all theatres
        /// </summary>
        /// <returns></returns>
        IEnumerable<string> ListTheatres();

        // TODO: document this method, its parameters, return value, exceptions, etc.
        void AddPerformance(string theatreName, string performanceTitle, DateTime startDateTime, TimeSpan duration, decimal price);

        // TODO: document this method, its parameters, return value, exceptions, etc.
        IEnumerable<IPerformance> ListAllPerformances();

        // TODO: document this method, its parameters, return value, exceptions, etc.
        IEnumerable<IPerformance> ListPerformances(string theatreName);       
    }
}