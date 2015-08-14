namespace Code_First
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web.Script.Serialization;
    using DTO;

    class MoviesProgram
    {
        static void Main()
        {
            var context = new MoviesContext();
            Console.WriteLine(context.Ratingses.Count());

            //var json = File.ReadAllText(@"../../../countries.json");
            ////Console.WriteLine(json);
            //var jsSerialized = new JavaScriptSerializer();
            //var parsedData = jsSerialized.Deserialize<IEnumerable<CountryDTO>>(json);

            //foreach (var country in parsedData)
            //{
            //    Console.WriteLine(country.name);
            //}
        }
    }
}
