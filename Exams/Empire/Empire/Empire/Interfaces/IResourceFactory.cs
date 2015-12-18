namespace Empire.Interfaces
{
    using Enum;

    public interface IResourceFactory
    {
        IResource CreateResource(ResourceType resourceType, int qty);
    }
}