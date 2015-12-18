namespace Empire.Interfaces
{
    using Models.EventHandlers;

    public interface IUnitProducer
    {
        event UnitProducerEventHandler OnUnitProducer;
    }
}