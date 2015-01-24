using System;

class OnesAndZeroes
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string strNumbers = Convert.ToString(n,2).PadLeft(32,'0');
        string [,] one = {{".#."},{"##."},{".#."},{".#."},{"###"}};
        string [,] zeroe = {{"###"},{"#.#"},{"#.#"},{"#.#"},{"###"}};
        
        for (int i = 0; i < 5; i++)
        {
            for (int j = 16; j < 32; j++)
            {
                if (j!=31)
                {
                    if (strNumbers[j]=='0')
                    {
                        Console.Write(zeroe[i,0] + ".");
                    }
                    else
                    {
                        Console.Write(one[i,0] + ".");
                    }
                }
                else
                {
                    if (strNumbers[j] == '0')
                    {
                        Console.WriteLine(zeroe[i, 0]);
                    }
                    else
                    {
                        Console.WriteLine(one[i, 0]);
                    }
                }
            }
        }
        
    }
}
