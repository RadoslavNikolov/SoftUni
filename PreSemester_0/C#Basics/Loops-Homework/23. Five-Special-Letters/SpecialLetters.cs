using System;
using System.Collections.Generic;

class specialLetters
{
    static void Main()
    {
        int start = int.Parse(Console.ReadLine());
        int end = int.Parse(Console.ReadLine());
        char[] letters = { 'a', 'b', 'c', 'd', 'e' };
        int[] lettersWeight = { 5, -12, 47, 7, -32 };
        List<string> output = new List<string>();
        List<char> temp = new List<char>(); //used only for check if letter allready exist in the string

        for (int i1 = 0; i1 < 5; i1++)
        {
            for (int i2 = 0; i2 < 5; i2++)
            {
                for (int i3 = 0; i3 < 5; i3++)
                {
                    for (int i4 = 0; i4 < 5; i4++)
                    {
                        for (int i5 = 0; i5 < 5; i5++)
                        {
                            int tempWeight = 0;
                            string tempLetters = "" + letters[i1] + letters[i2] + letters[i3] + letters[i4] + letters[i5];
                            foreach (var item in tempLetters)
                            {
                                if (!temp.Contains(item))
                                {
                                    temp.Add(item);
                                }
                            }

                            for (int i = 0; i < temp.Count; i++)
                            {
                                for (int j = 0; j < letters.Length; j++)
                                {
                                    if (temp[i] == letters[j])
                                    {
                                        tempWeight += (i + 1) * lettersWeight[j];
                                    }
                                }
                            }

                            if (tempWeight >= start && tempWeight <= end)
                            {

                                output.Add(tempLetters);
                            }
                            temp.Clear();
                        }
                    }
                }
            }
        }
        output.Sort();
        if (output.Count == 0)
        {
            Console.WriteLine("No");
        }
        else
        {
            for (int i = 0; i < output.Count; i++)
            {
                Console.Write("{0} ", output[i]);
            }
        }
        Console.WriteLine();

    }
}
