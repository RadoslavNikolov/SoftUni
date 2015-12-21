namespace Blobs.Models.Inftrastructure
{
    using Infrastructure;

    public interface IUnit : IAttacker, IDestroyable, IUpdatable
    {
        string Name { get;}

        IBehavior Behavior { get;}

        IAttack Attack { get;}
    }
}