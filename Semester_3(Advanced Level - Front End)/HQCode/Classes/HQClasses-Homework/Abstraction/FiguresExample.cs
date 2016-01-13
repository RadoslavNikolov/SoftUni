using System;

namespace Abstraction
{
    using System.Collections.Generic;
    using Interfaces;
    using Models;

    class FiguresExample
    {
        static void Main()
        {
            List<IFigure> figures = new List<IFigure>();

            var circle = new Circle(5);
            figures.Add(circle);
            var rect = new Rectangle(2, 3);
            figures.Add(rect);

            figures.ForEach(Console.WriteLine);
        }
    }
}
