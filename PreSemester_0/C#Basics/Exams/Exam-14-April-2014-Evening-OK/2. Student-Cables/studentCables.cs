using System;

class studentCables
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int sum = 0;  //in centimeters
        int count = 0;
        for (int i = 0; i < n; i++)
        {
            int cableLenght = int.Parse(Console.ReadLine());
            string measure = Console.ReadLine();
            if (measure=="meters")
            {
                cableLenght *= 100;
            }
            if (cableLenght>=20)
            {
                sum += cableLenght;
                count++;
            }
        }
        sum = sum - (count - 1) * 3;
        Console.WriteLine(sum/504);
        Console.WriteLine(sum%504);
    }
}
