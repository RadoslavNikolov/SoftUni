using System;
using System.Collections.Generic;
using Wintellect.PowerCollections;

public class PersonCollection : IPersonCollection
{
    private Dictionary<string, Person> personsByEmail = new Dictionary<string, Person>();
    private Dictionary<string, SortedSet<Person>> personsByEmailDomain = new Dictionary<string, SortedSet<Person>>();
    private Dictionary<string, SortedSet<Person>> personsByNameAndTown = new Dictionary<string, SortedSet<Person>>();
    private OrderedDictionary<int, SortedSet<Person>> personsByAge  = new OrderedDictionary<int, SortedSet<Person>>();
    private Dictionary<string, OrderedDictionary<int, SortedSet<Person>>> personsByTownAndAge  = new Dictionary<string, OrderedDictionary<int, SortedSet<Person>>>();

    public bool AddPerson(string email, string name, int age, string town)
    {
        if (this.FindPerson(email) != null)
        {
            return false;
        }

        var person = new Person()
        {
            Name = name,
            Age = age,
            Email = email,
            Town = town
        };

        //Add by email
        this.personsByEmail.Add(email,person);

        //Add by email domain
        var emailDomain = this.ExtractEmailDomain(email);
        this.personsByEmailDomain.AppendValueToKey(emailDomain, person);

        //Add by name and town
        var nameAndTown = this.CombineNameAndTown(name, town);
        this.personsByNameAndTown.AppendValueToKey(nameAndTown, person);

        //Add by age
        this.personsByAge.AppendValueToKey(age, person);

        //Add by town and age
        this.personsByTownAndAge.EnsureKeyExists(town);
        this.personsByTownAndAge[town].AppendValueToKey(age, person);

        return true;
    }  

    public bool DeletePerson(string email)
    {
        var person = this.FindPerson(email);

        if (person == null)
        {
            return false;
        }

        //delete person from personByEmail
        var personDeleted = this.personsByEmail.Remove(email);

        //delete person from personByEmailDomain
        var emailDomain = this.ExtractEmailDomain(email);
        this.personsByEmailDomain[emailDomain].Remove(person);

        //delete person from personByNameAndTown
        string nameAndTown = this.CombineNameAndTown(person.Name, person.Town);
        this.personsByNameAndTown[nameAndTown].Remove(person);

        //Delete person from personByAge
        this.personsByAge[person.Age].Remove(person);

        //delete person by name and age
        this.personsByTownAndAge[person.Town][person.Age].Remove(person);

        return true;
    }

    public int Count
    {
        get { return this.personsByEmail.Count; }
    }

    public Person FindPerson(string email)
    {
        Person person;
        var personExist = this.personsByEmail.TryGetValue(email, out person);

        return person;
    }

    public IEnumerable<Person> FindPersons(string emailDomain)
    {
        return this.personsByEmailDomain.GetValuesForKey(emailDomain);
    }

    public IEnumerable<Person> FindPersons(string name, string town)
    {
        var nameAndTown = this.CombineNameAndTown(name, town);
        return this.personsByNameAndTown.GetValuesForKey(nameAndTown);

    }  

    public IEnumerable<Person> FindPersons(int startAge, int endAge)
    {
        var personsInRange = this.personsByAge.Range(startAge, true, endAge, true);

        //if (personsInRange == null)
        //{
        //    yield break;
        //}

        foreach (var personByAge in personsInRange)
        {

            foreach (var person in personByAge.Value)
            {
                yield return person;
            }
        }
    }

    public IEnumerable<Person> FindPersons(
        int startAge, int endAge, string town)
    {
        if (!this.personsByTownAndAge.ContainsKey(town))
        {
            //return empty sequence of persons
            yield break;
        }

        var personsInRange = this.personsByTownAndAge[town].Range(startAge, true, endAge, true);

        foreach (var personByAge in personsInRange)
        {
            foreach (var person in personByAge.Value)
            {
                yield return person;
            }
        }
    }

    private string ExtractEmailDomain(string email)
    {
        var domain = email.Split('@')[1];

        return domain;
    }

    private string CombineNameAndTown(string name, string town)
    {
        const string separator = "|!|";
        return name + separator + town;
    }
}
