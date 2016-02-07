namespace Company_Hierarchy.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Helpers;
    using Interrfaces;

    public class Developer : RegularEmployee, IDeveloper, IPerson
    {
        private ICollection<IProject> projects;
 
        public Developer(string firstName, string lastName, decimal salary, string department) 
            : base(firstName, lastName, salary, department)
        {
            this.projects = new HashSet<IProject>();
        }

        public virtual ICollection<IProject> Projects
        {
            get { return this.projects; }
            set { this.projects = value; }
        }

        public bool CloseProjectById(int projectId)
        {
            if (!RightsValidator.ValidateProjectClosingUserRights(projectId, this.Id))
            {
                Console.WriteLine("You do not have rights to close project with id: " + projectId);
                return false;

            }

            CompanyDB.projects.FirstOrDefault(p => p.Id == projectId).State = States.Close;
            Console.WriteLine("Employee: " + this.FirstName + " successfully closed oroject with id: " + projectId);

            return true;
        }

        public override string ToString()
        {
            var output = new StringBuilder(base.ToString());
            output.AppendLine("List of projects participating:");
            this.projects.ToList().ForEach(p => output.AppendLine(p.ToString()));
            return output.ToString();
        }
    }
}