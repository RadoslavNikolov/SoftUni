namespace Shapes
{
    using System;
    using Models;

    class ShapesProgram
    {
        static void Main()
        {
            var rhombus = new Rhombus(15.5,20.3);
            var rectangle = new Rectangle(5,5);
            Console.WriteLine(rhombus.CalculateArea());
            Console.WriteLine(rhombus.CalculatePerimeter());
            Console.WriteLine(new string('=', Console.BufferWidth));
            Console.WriteLine(rectangle.CalculateArea());
            Console.WriteLine(rectangle.CalculatePerimeter());
            Console.WriteLine(new string('=', Console.BufferWidth));
            var circle = new Circle(5.53, new Point(0,0));
            Console.WriteLine(circle.CalculateArea());
            Console.WriteLine(circle.CalculatePerimeter());
        }
    }
}
