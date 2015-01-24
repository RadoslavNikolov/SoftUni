using System;

class fourDigitNumber
{
    static void Main(string[] args)
    {
        
        
        string number = Console.ReadLine();
        if (Convert.ToInt32(number)<1000)
        {
            Console.WriteLine("Invalid input!");
            return;
        }
        else
        {
            int sum = 0;
            foreach (var item in number)
            {
                sum += (int)char.GetNumericValue(item);
            }
            Console.Write("{0,-15}", "number");
            Console.Write("{0,-15}", "sum");
            Console.Write("{0,-15}", "reversed");
            Console.Write("{0,-15}", "last in front");
            Console.Write("{0,-15}\n", "sec and thrd excg");
            Console.Write("{0,-15}", number);
            Console.Write("{0,-15}", sum);

            for (int i = number.Length-1; i>=0; i--)
            {
                Console.Write(number[i]);
            }
            Console.Write("           ");
            Console.Write("{0}{1}{2}{3}", number[number.Length-1], number[0],number[1],number[2]);
            Console.Write("           ");
            Console.Write("{0}{1}{2}{3}\n", number[0], number[2], number[1], number[3]);
        }
    }
}
