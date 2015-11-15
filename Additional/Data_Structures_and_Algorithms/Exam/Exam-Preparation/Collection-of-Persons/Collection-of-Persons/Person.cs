using System;

public class Person : IComparable<Person>
{
    public string Email { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Town { get; set; }
    public int CompareTo(Person other)
    {
        return this.Email.CompareTo(other.Email);

        ////if we want multiple sorting

        //int result = this.Email.CompareTo(other.Email);

        //if (result == 0)
        //{
        //    result = this.Age.CompareTo(other.Age);
        //}

        //if (result == 0)
        //{
        //    result = this.Town.CompareTo(other.Town);
        //}

        //return result;
    }
}
