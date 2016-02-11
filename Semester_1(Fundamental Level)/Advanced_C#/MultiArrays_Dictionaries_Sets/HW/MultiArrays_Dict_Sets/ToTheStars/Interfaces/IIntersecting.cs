namespace ToTheStars.Interfaces
{
    using Models;

    public interface IIntersecting
    {
        bool IsIntersecting(Point2D starshipCoordinates);
    }
}