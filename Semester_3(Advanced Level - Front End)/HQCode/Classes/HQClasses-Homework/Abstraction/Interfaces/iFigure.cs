namespace Abstraction.Interfaces
{
    public interface IFigure
    {
        double Radius { get; }

        double Height { get; }

        double Width { get; }

        double CalcPerimeter();

        double CalcSurface();
    }
}