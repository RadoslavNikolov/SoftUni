using System;

namespace Exception_Handling
{
    public class TestPerson
    {
        static void Main()
        {
            try
            {
                Person pesho = new Person("Pesho", "Peshev", 24);
                Person noName = new Person(string.Empty, "Goshev", 31);
                Person noLastName = new Person("Ivan", null, 63);
                Person negativeAge = new Person("Stoyan", "Kolev", -1);
                Person tooOldForThisProgram = new Person("Iskren", "Ivanow", 121);

            }
            catch (ArgumentNullException ex)
            {
                Console.Error.WriteLine("Exception thrown: {0}", ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.Error.WriteLine("Exception thrown: {0}", ex.Message);
            }
        }
    }
}
