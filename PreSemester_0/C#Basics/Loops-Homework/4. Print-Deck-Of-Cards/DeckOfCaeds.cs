using System;

class DeckOfCaeds
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        char[] cardSuits = {'\u2663', '\u2666', '\u2665', '\u2660' };
        for (int i = 2; i <= 14; i++)
        {
            string output = "";
            for (int j = 0; j < cardSuits.Length; j++)
            {
                string str = "";
                switch (i)
                {
                    case 2: str += i; break;
                    case 3: str += i; break;
                    case 4: str += i; break;
                    case 5: str += i; break;
                    case 6: str += i; break;
                    case 7: str += i; break;
                    case 8: str += i; break;
                    case 9: str += i; break;
                    case 10: str += i; break;
                    case 11: str += 'J'; break;
                    case 12: str += 'D'; break;
                    case 13: str += 'K'; break;
                    case 14: str += 'A'; break;
                    default:
                        break;
                }
                output += str + cardSuits[j] + " ";
            }
            Console.WriteLine(output.Trim());
        }
    }
}
