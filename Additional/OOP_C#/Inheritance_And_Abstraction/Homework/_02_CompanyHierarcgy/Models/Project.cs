namespace CompanyHierarcgy.Models
{
    using System;
    using Interfaces;

    public class Project : IProject
    {
        private string name;

        public Project(string name, string details, DateTime startDate)
        {
            this.Name = name;
            this.Details = details;
            this.State = ProjectState.Open;
            this.StartDate = startDate;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Project name cannot be empty.");
                }

                this.name = value;

            }
        }
        public string Details { get; set; }
        public DateTime StartDate { get; set; }
        public ProjectState State { get; set; }
        public void CloseProject()
        {
            this.State = ProjectState.Closed;
        }
    }
}