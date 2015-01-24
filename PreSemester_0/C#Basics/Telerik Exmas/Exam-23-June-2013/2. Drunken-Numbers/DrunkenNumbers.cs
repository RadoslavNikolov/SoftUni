using System;

class DrunkenNumbers
{
    static void Main()
    {
        int round = int.Parse(Console.ReadLine());
        int mitkoBeers = 0;
        int vladkoBeers = 0;

        for (int i = 0; i < round; i++)
        {
            string input = Console.ReadLine().Trim('-').TrimStart('0');

            for (int j = 0; j < input.Length; j++)
            {
                if (input.Length % 2 == 0)
                {
                    if (j < input.Length/2)
                    {
                        mitkoBeers += (int)char.GetNumericValue(input[j]);
                    }
                    else
                    {
                        vladkoBeers += (int)char.GetNumericValue(input[j]);
                    }
                }
                else
                {
                    if (j < input.Length / 2)
                    {
                        mitkoBeers += (int)char.GetNumericValue(input[j]);
                    }
                    else if (j > input.Length / 2)
                    {
                        vladkoBeers += (int)char.GetNumericValue(input[j]);
                    }
                    else
                    {
                        mitkoBeers += (int)char.GetNumericValue(input[j]);
                        vladkoBeers += (int)char.GetNumericValue(input[j]);
                    }
                }
            }
        }

        if (mitkoBeers > vladkoBeers)
        {
            Console.WriteLine("M {0}", mitkoBeers - vladkoBeers);
        }
        else if (mitkoBeers < vladkoBeers)
        {
            Console.WriteLine("V {0}", vladkoBeers - mitkoBeers);

        }
        else
        {
            Console.WriteLine("No {0}", mitkoBeers+vladkoBeers);
        }
    }
}
