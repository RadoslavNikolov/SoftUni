namespace Company_Hierarchy.Models
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;
    using Helpers;
    using Human_Worker_Student.Helpers;
    using Interrfaces;

    public class Project : IProject
    {
        private static int _id;
        private string name;
        private ICollection<IPerson> developers; 

        public Project(string name, DateTime startDate, string details = "no details")
        {
            Project._id++;
            this.Name = name;
            this.Id = Project._id;
            this.StartDate = startDate;
            this.Details = details;
            this.State = States.Open;
            this.developers = new HashSet<IPerson>();
        }

        public int Id { get; private set; }

        public string Name
        {
            get { return this.name; }
            set
            {
                CustomValidators.ValidateName(value);
                this.name = value;
            }
        }

        public DateTime StartDate { get; set; }

        public string Details { get; set; }

        public States State { get; set; }

        public virtual ICollection<IPerson> Developers
        {
            get { return this.developers; }
            set { this.developers = value; }
        }

        public void CloseProject()
        {        
            this.State = States.Close;
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine(
                String.Format("Type: {0} / Id: {1} / Name: {2} / Details: {3} / StartDate: {4} / Status: {5}",
                this.GetType().Name, this.Id, this.Name, this.Details, this.StartDate, this.State));
            return output.ToString();
        }
    }
}