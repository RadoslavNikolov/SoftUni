using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Count_Words_Case_Insensitive
{
    class CountWordsCI
    {
        private static readonly string TEXT =
            "Paid was hill sir high. For him precaution any advantages dissimilar comparison few terminated projecting. Prevailed discovery immediate objection of ye at. Repair summer one winter living feebly pretty his. In so sense am known these since. Shortly respect ask cousins brought add tedious nay. Expect relied do we genius is. On as around spirit of hearts genius. Is raptures daughter branched laughter peculiar in settling.";

        static void Main(string[] args)
        {
            IDictionary<String, int> wordOccurrenceMap = GetWordOccurrenceMap(TEXT);

            PrintWordOccurrence(wordOccurrenceMap);

        }

        private static void PrintWordOccurrence(IDictionary<string, int> wordOccurrenceMap)
        {
            foreach (KeyValuePair<string, int> wordEntry in wordOccurrenceMap)
            {
                Console.WriteLine("Word '{0}' occurs {1} time(s) in the text", wordEntry.Key, wordEntry.Value);
            }

            Console.ReadKey();
        }

        private static IDictionary<string, int> GetWordOccurrenceMap(string text)
        {
            string[] tokens = text.Trim().Split(' ', '.', ',', '-', '?', '!');

            IDictionary<string, int> words = new SortedDictionary<string, int>(new CaseInsensitiveComparer());

            foreach (var word in tokens)
            {
                if (string.IsNullOrEmpty(word.Trim()))
                {
                    continue;
                }

                int count;

                if (!words.TryGetValue(word, out count))
                {
                    count = 0;
                }

                words[word] = count + 1;
            }

            return words;
        }
    }

    public class CaseInsensitiveComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return string.Compare(x, y, true);
        }
    }
}
