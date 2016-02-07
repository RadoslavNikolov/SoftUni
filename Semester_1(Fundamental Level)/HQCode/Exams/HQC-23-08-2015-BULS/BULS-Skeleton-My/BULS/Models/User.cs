namespace BangaloreUniversityLearningSystem.Models
{
    using System;
    using System.Collections.Generic;
    using Utilities;
    using Utilities.Enums;

    public class User
    {
        private readonly IList<Course> courses; 
        private string username;
        private string passwordHash;
        
        public User(string username, string password, Role role)
        {
            this.Username = username;
            this.Password = password;
            this.Role = role;
            this.courses = new List<Course>();
        }

        public string Username
        {
            get
            {
                return this.username;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The username cannot be null or empty");
                }

                if (value.Length < 5)
                {
                    throw new ArgumentException("The username must be at least 5 symbols long.");
                }

                this.username = value;
            }
        }

        public string Password
        {
            get
            {
                return this.passwordHash;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The password cannot be null or empty");
                }

                if (value.Length < 6)
                {
                    throw new ArgumentException("The password must be at least 6 symbols long.");
                }

                string hashPassword = HashUtilities.HashPassword(value);
                this.passwordHash = hashPassword;
            }
        }

        public Role Role { get; private set; }

        public IEnumerable<Course> Courses
        {
            get { return this.courses; }
        }

        public void EnrollInCourse(Course course)
        {
            this.courses.Add(course);
        }
    }
}