namespace SULS.Models
{
    using System.Collections.Generic;

    public class OnsideSudent : CurrentStudent
    {
        private ICollection<Visit> visits; 

        public OnsideSudent(string fristName, string lastName, int age, string studentNumber, double avgGrade, string currentCourse) : base(fristName, lastName, age, studentNumber, avgGrade, currentCourse)
        {
            this.visits = new HashSet<Visit>();
        }

        public virtual ICollection<Visit> Visits
        {
            get { return this.visits; }
            set { this.visits = value; }
        }

        public override string ToString()
        {
            var result = base.ToString();

            foreach (var visit in this.visits)
            {
                result += visit;
            }

            return result;
        }
    }
}