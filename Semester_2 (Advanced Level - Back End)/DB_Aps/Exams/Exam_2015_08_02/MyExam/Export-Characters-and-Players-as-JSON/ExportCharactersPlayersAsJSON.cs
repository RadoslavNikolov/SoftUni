namespace Export_Characters_and_Players_as_JSON
{
    using System.IO;
    using System.Linq;
    using Diablo_DataBase_First;
    using Newtonsoft.Json;

    class ExportCharactersPlayersAsJson
    {
        static void Main()
        {
            var context = new DiabloEntities();
            var characters = context.Characters
                .OrderBy(c => c.Name)
                .Select(c => new
                {
                    name = c.Name,
                    playedBy = c.UsersGames
                        .Select(u => u.User.Username).ToList()
                });

            //var json = JsonConvert.SerializeObject(characters, Formatting.Indented);
            var json = JsonConvert.SerializeObject(characters);

            File.WriteAllText(@"../../../Exports/characters.json", json);
        }
    }
}
