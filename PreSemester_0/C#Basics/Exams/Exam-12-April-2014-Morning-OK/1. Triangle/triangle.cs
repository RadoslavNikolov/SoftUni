using System;

class triangle
{
    static void Main()
    {
        int a_x = int.Parse(Console.ReadLine());
        int a_y = int.Parse(Console.ReadLine());
        int b_x = int.Parse(Console.ReadLine());
        int b_y = int.Parse(Console.ReadLine());
        int c_x = int.Parse(Console.ReadLine());
        int c_y = int.Parse(Console.ReadLine());


        double ab = Math.Sqrt(Math.Pow(Math.Abs(a_x - b_x), 2) + Math.Pow(Math.Abs(a_y - b_y), 2));
        double ac = Math.Sqrt(Math.Pow(Math.Abs(a_x - c_x), 2) + Math.Pow(Math.Abs(a_y - c_y), 2));
        double bc = Math.Sqrt(Math.Pow(Math.Abs(b_x - c_x), 2) + Math.Pow(Math.Abs(b_y - c_y), 2));

        if (ab+ac>bc && ab+bc>ac && ac+bc>ab)
        {
            Console.WriteLine("Yes");
            double p=(ab+ac+bc)/2;   //halfperimeter
            Console.WriteLine("{0:0.00}",Math.Sqrt(p*(p-ab)*(p-ac)*(p-bc)));
        }
        else
        {
            Console.WriteLine("No");
            Console.WriteLine("{0:0.00}", ab);
        }


    }
}
