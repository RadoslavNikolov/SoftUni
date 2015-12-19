namespace Empire.Interfaces
{
    using Enum;

    public interface IResource
    {
        ResourceType ResourceType { get; }

        int Quantity { get; }
    }
}