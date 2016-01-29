namespace BangaloreUniversityLearningSystem.Models
{
    using System;

    public class Lecture
    {
        private string name;

        public Lecture(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The lecture name cannot be null or empty");
                }

                if (value.Length < 3)
                {
                    throw new ArgumentException("The lecture name must be at least 3 symbols long.");                   
                }

                this.name = value;
            }
        }
    }
}