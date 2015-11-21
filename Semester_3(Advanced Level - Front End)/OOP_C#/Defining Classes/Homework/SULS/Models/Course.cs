namespace SULS.Models
{
    using System;
    using System.Text;

    public class Course
    {
        private string name;
        private string createdFrom;

        public Course(string name, DateTime createdOn, string createdFrom)
        {
            this.Name = name;
            this.CreatedOn = createdOn;
            this.CreatedFrom = createdFrom;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Course name cannot be null!");
                }

                this.name = value;
            }
        }

        public DateTime CreatedOn { get; set; }

        public string CreatedFrom
        {
            get { return this.createdFrom; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw  new ArgumentNullException("Course cannot be anonymous!");
                }

                this.createdFrom = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine($"    Course name: {this.name}");
            result.AppendLine($"    Created from: {this.CreatedFrom}");
            result.AppendLine($"    Created on: {this.CreatedOn}");
            result.AppendLine($"    {new string('.', Console.BufferWidth/2)}");

            return result.ToString();
        }
    }
}