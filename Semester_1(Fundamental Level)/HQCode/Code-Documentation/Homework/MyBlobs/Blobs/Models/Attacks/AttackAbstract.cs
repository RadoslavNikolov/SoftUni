namespace Blobs.Models.Attacks
{
    using Inftrastructure;

    public abstract class AttackAbstract : IAttack
    {
        public IUnit Unit { get; set; }

        public abstract int ProduceAttack();
    }
}