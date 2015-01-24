using System;
using System.Collections.Generic;
using System.Text;

class MagicWords
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int maxLenght=int.MinValue;
        List<string> strList = new List<string>();

        for (int i = 0; i < n; i++)
        {
            string word = Console.ReadLine();
            strList.Add(word);
        }

        for (int pos = 0; pos < strList.Count; pos++)
        {
            string word = strList[pos];
            int newPos = strList[pos].Length % (strList.Count + 1);
            strList[pos] = null;
            strList.Insert(newPos, word);
            strList.Remove(null);
        }

        foreach (var item in strList)
        {
            maxLenght = Math.Max(maxLenght, item.Length);
        }

        StringBuilder resul = new StringBuilder();
        for (int index = 0; index < maxLenght; index++)
        {
            for (int i = 0; i < strList.Count; i++)
            {
                if (index < strList[i].Length)
                {
                    resul.Append(strList[i][index]);
                }
            }
        }

        Console.WriteLine(resul);
    }
}
