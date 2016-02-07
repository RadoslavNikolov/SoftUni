namespace Methods
{
    using System;
    using Helpers;
    using Models;

    public class HomeworkTest
    {
        public static void Main()
        {
            Console.WriteLine(GeometryUtils.CalcTriangleArea(3, 4, 5));

            Console.WriteLine(NumbersUtils.DigitToWord(5));

            Console.WriteLine(NumbersUtils.FindMax(5, -1, 3, 2, 14, 2, 3));

            NumbersUtils.PrintNumberInFormat(1.3, "f");
            NumbersUtils.PrintNumberInFormat(0.75, "%");
            NumbersUtils.PrintNumberInFormat(2.30, "r");

            bool horizontal, vertical;
            var p1 = new Pont2D(3, -1);
            var p2 = new Pont2D(3, 2.5);
            Console.WriteLine(GeometryUtils.CalcDistance(p1, p2, out horizontal, out vertical));
            Console.WriteLine("Horizontal? " + horizontal);
            Console.WriteLine("Vertical? " + vertical);

            Student peter = new Student() { FirstName = "Peter", LastName = "Ivanov" };
            peter.OtherInfo = "From Sofia, born at 17.03.1992";

            Student stella = new Student() { FirstName = "Stella", LastName = "Markova" };
            stella.OtherInfo = "From Vidin, gamer, high results, born at 03.11.1993";

            Console.WriteLine("{0} older than {1} -> {2}",
                peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        } 
    }
}