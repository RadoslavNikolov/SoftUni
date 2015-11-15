namespace BiDictionary
{
    using System;

    class BiDictionaryProgram
    {
        static void Main()
        {
            var biDicCollection = new BiDictionary<string, double, string>();
            biDicCollection.Add("Pesho", 1, "cool");
            biDicCollection.Add("Pesho", 2, "not so cool");
            biDicCollection.Add("Minka", 1.2, "85D");
            biDicCollection.Add("Penka", 1.5, "to small to find");

            var test = biDicCollection.Find("Pesho");
            foreach (var value in test)
            {
                Console.WriteLine(value);
            }

            test = biDicCollection.Find("Pesho", 2);
            foreach (var value in test)
            {
                Console.WriteLine(value);
            }

            test = biDicCollection.Find(1.2);
            foreach (var value in test)
            {
                Console.WriteLine(value);
            }
        }
    }
}
