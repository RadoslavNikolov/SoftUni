namespace BugTracker.RestServices.Models.ViewModels
{
    using System;
    using System.Runtime.InteropServices.ComTypes;
    using Data.Models;

    public class BugViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Status { get; set; }

        public string Author { get; set; }

        public DateTime DateCreated { get; set; }
    }
}