namespace Battleships.Ships
{
    using Interfaces;

    public abstract class BattleShip : Ship, IAttack
    {
        protected BattleShip(string name, double lengthInMeters, double volume) 
            : base(name, lengthInMeters, volume)
        {
        }

        protected void DestroyShip(Ship target)
        {
            target.IsDestroyed = true;
        }

        public abstract string Attack(Ship targetShip);
    }
}