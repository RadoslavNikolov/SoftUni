using System;
using System.Threading;
using System.Globalization;

class Garden
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
        int tomatoSeeds = int.Parse(Console.ReadLine());
        int tomatoArea = int.Parse(Console.ReadLine());
        int cucumberSeed = int.Parse(Console.ReadLine());
        int cucumberArea = int.Parse(Console.ReadLine());
        int potatoSeeds = int.Parse(Console.ReadLine());
        int potatoArea = int.Parse(Console.ReadLine());
        int carrotSeeds=int.Parse(Console.ReadLine());
        int carrotArea = int.Parse(Console.ReadLine());
        int cabbageSeeds = int.Parse(Console.ReadLine());
        int cabbageArea = int.Parse(Console.ReadLine());
        int beansSeeds = int.Parse(Console.ReadLine());

        int beansArea = 250 - tomatoArea - cucumberArea - potatoArea - carrotArea - cabbageArea;
        double toralCostOfBeans = tomatoSeeds * 0.5 + cucumberSeed * 0.4 + potatoSeeds * 0.25 + carrotSeeds * 0.6 + cabbageSeeds * 0.3 + beansSeeds * 0.4;

        Console.WriteLine("Total costs: {0:F2}", toralCostOfBeans);
        if (beansArea<0)
        {
            Console.WriteLine("Insufficient area");
        }
        else if (beansArea==0)
        {
            Console.WriteLine("No area for beans");
        }
        else
        {
            Console.WriteLine("Beans area: {0}", beansArea);
        }

    }
}
