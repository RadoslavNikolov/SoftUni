using System;

class printNumberAsWord
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        int hundredDigit = (number / 100) % 10;
        int tensDigit = (number / 10) % 10;
        int unitsDigit = number % 10;

        if (number > 99)
        {
            Console.Write("{0}", HundredsWord(hundredDigit));
            number = number % 100;
            if (number <= 19 && number > 0)
            {
                Console.WriteLine(" and {0}", UnitsWord(number).ToLower());
            }
            else
            {
                Console.Write("and {0}", TensWord(tensDigit).ToLower());
                //if (unitsDigit > 0)
                //{
                    Console.WriteLine(" {0}", UnitsWord(unitsDigit).ToLower());
                //}
            }
        }
        else if (number > 19)
        {
            Console.Write("{0}", TensWord(tensDigit));
            //if (unitsDigit > 0)
            //{
                Console.WriteLine(" {0}", UnitsWord(unitsDigit).ToLower());
            //}
        }
        else
        {
            Console.WriteLine("{0}", UnitsWord(number));
        }
    }

    private static string TensWord(int tensDigit)
    {
        string tens = "";
        switch (tensDigit)
        {
            case 2: tens += "Twenty"; break;
            case 3: tens += "Thirty"; break;
            case 4: tens += "Fourty"; break;
            case 5: tens += "Fifty"; break;
            case 6: tens += "Sixty"; break;
            case 7: tens += "Seventy"; break;
            case 8: tens += "Eighty"; break;
            case 9: tens += "Ninety"; break;

            default:
                break;
        }
        return tens;
    }

    private static string UnitsWord(int number)
    {
        string units = "";
        switch (number)
        {
            case 0: units += "Zero"; break;
            case 1: units += "One"; break;
            case 2: units += "Two"; break;
            case 3: units += "Three"; break;
            case 4: units += "Four"; break;
            case 5: units += "Five"; break;
            case 6: units += "Six"; break;
            case 7: units += "Seven"; break;
            case 8: units += "Eight"; break;
            case 9: units += "Nine"; break;
            case 10: units += "Ten"; break;
            case 11: units += "Eleven"; break;
            case 12: units += "Twelve"; break;
            case 13: units += "Thirteen"; break;
            case 14: units += "Fourteen"; break;
            case 15: units += "Fifteen"; break;
            case 16: units += "Sixteen"; break;
            case 17: units += "Seventeen"; break;
            case 18: units += "Eighteen"; break;
            case 19: units += "Nineteen"; break;

            default:
                break;
        }
        return units;
    }


    private static string HundredsWord(int hundredDigit)
    {
        string hundreds = "";
        switch (hundredDigit)
        {
            case 1: hundreds += "One hundred"; break;
            case 2: hundreds += "Two hundred"; break;
            case 3: hundreds += "Three hundred"; break;
            case 4: hundreds += "Four hundred"; break;
            case 5: hundreds += "Five hundred"; break;
            case 6: hundreds += "Six hundred"; break;
            case 7: hundreds += "Seven hundred"; break;
            case 8: hundreds += "Eight hundred"; break;
            case 9: hundreds += "Nine hundred"; break;

            default:
                break;
        }
        return hundreds;
    }
}
