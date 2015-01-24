using System;
using System.Threading;

class gravitation
{
    static void Main()
    {
        for (int i = 0; i < 3; i++)
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("en-US");
            Console.Write("Enter your weight: ");
            double earthWeight = double.Parse(Console.ReadLine());
            Console.WriteLine("Your Moon weight is: {0}", earthWeight*0.17);
        }
    }
}
