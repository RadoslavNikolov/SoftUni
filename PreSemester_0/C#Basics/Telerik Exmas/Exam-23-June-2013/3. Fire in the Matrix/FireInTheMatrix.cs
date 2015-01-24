using System;

class FireInTheMatrix
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        //print upper part
        for (int i = 0; i < n/2; i++)
        {
            string output = new string('.', (n - 2 - i * 2) / 2) + '#' + new string('.', i * 2) + '#' + new string('.', (n - 2 - i * 2) / 2);
            Console.WriteLine(output);
        }

        //print middle part
        for (int i = 0; i < n/4; i++)
        {
            string output = new string('.', i) + '#' + new string('.', n-2-2*i) + '#' + new string('.', i);
            Console.WriteLine(output);         
        }

        Console.WriteLine(new string('-',n));

        //print lower part
        for (int i = 0; i < n/2; i++)
        {
            string output = new string('.', i) + new string('\\', n / 2 - i) + new string('/', n / 2 - i) + new string('.', i);
            Console.WriteLine(output);
        }
    }
}
