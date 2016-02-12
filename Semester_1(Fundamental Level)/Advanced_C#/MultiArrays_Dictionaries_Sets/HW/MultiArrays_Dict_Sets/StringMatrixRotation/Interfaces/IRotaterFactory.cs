namespace StringMatrixRotation.Interfaces
{
    public interface IRotaterFactory
    {
        IRotater GetRotater(int degrees);
    }
}