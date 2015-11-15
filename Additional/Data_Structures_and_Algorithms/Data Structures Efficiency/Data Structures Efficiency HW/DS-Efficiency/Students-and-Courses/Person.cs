namespace Students_and_Courses
{
    using System;

    public class Person : IComparable<Person>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int CompareTo(Person other)
        {
            int result = String.Compare(this.LastName, other.LastName, StringComparison.OrdinalIgnoreCase);

            if (result == 0)
            {
                result = String.Compare(this.FirstName, other.FirstName, StringComparison.OrdinalIgnoreCase);
            }

            return result;
        }

        public override string ToString()
        {
            string result = this.FirstName + ' ' + this.LastName;

            return result;
        }
    }
}