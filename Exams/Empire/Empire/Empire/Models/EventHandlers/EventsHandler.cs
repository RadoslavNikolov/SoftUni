namespace Empire.Models.EventHandlers
{
    using EventsArgs;

    public delegate void ResourceProducerEventHandler(object sender, ResourceProducerEventArgs e);

    public delegate void UnitProducerEventHandler(object sender, UnitProducerEventArgs e);
}