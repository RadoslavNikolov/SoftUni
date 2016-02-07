namespace Blobs.Infrastructure
{
    public interface IOutputWriter
    {
        void Print(string message);
    }
}