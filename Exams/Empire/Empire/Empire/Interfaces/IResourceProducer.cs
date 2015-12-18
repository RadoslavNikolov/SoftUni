namespace Empire.Interfaces
{
    using Models.EventHandlers;

    public interface IResourceProducer
    {
        event ResourceProducerEventHandler OnResourceProducer;
    }
}