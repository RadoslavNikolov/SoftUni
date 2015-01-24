using System;

class printScotlandFlag
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        char letter = 'A';
        for (int i = 1; i <= n; i++)
        {
            if (n<3)
            {
                Console.WriteLine(letter);
                break;
            }
            if (i==1)
            {
                string str = letter.ToString();
                str += new string('#',n-2);
                letter++;
                if (letter > 'Z')
                {
                    letter = 'A';
                }
                str += letter.ToString();
                Console.WriteLine(str);
            }
            else if (i > 1 && i < n / 2 + 1)
            {
                string str = new string('~', i - 1);
                letter++;
                if (letter>'Z')
                {
                    letter = 'A';
                }
                str += letter.ToString() + new string('#', n - 2 - (i - 1) * 2);
                letter++;
                if (letter > 'Z')
                {
                    letter = 'A';
                }
                str += letter.ToString() + new string('~', i - 1);
                Console.WriteLine(str);
            }
            else if (i==n/2+1)
            {
                letter++;
                if (letter > 'Z')
                {
                    letter = 'A';
                }
                string str = new string('-', (n - 1) / 2) + letter + new string('-', (n - 1) / 2);
                Console.WriteLine(str);
            }
            else if (i>n/2+1 && i<n)
            {
                string str = new string('~', n-i);
                letter++;
                if (letter > 'Z')
                {
                    letter = 'A';
                }
                str += letter.ToString() + new string('#', n - 2 - (n-i)*2);
                letter++;
                if (letter > 'Z')
                {
                    letter = 'A';
                }
                str += letter.ToString() + new string('~', n-i);
                Console.WriteLine(str);
            }
            else if(i==n)
            {
                letter++;
                if (letter > 'Z')
                {
                    letter = 'A';
                }
                string str = letter.ToString();
                str += new string('#', n - 2);
                letter++;
                if (letter > 'Z')
                {
                    letter = 'A';
                }
                str += letter.ToString();
                Console.WriteLine(str);
            }
        }
    }
}

