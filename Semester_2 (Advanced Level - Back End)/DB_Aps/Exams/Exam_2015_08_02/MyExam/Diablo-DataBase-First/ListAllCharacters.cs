namespace Diablo_DataBase_First
{
    using System;
    using System.Linq;

    class ListAllCharacters
    {
        static void Main()
        {
            var context = new DiabloEntities();
            var characters = context.Characters
                .Select(c => c.Name).ToList();

            characters.ForEach(c => Console.WriteLine("Character: {0}", c));
        }
    }
}
