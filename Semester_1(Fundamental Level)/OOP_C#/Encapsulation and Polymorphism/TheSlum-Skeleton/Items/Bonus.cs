namespace TheSlum.Items
{
    using Interfaces;

    public abstract class Bonus : Item, ITimeoutable
    {
        protected Bonus(string id, int healthEffect, int defenseEffect, int attackEffect, int countDown) 
            : base(id, healthEffect, defenseEffect, attackEffect)
        {
            this.Countdown = countDown;
        }

        public int Timeout { get; set; }
        public int Countdown { get; set; }
        public bool HasTimedOut { get; set; }
    }
}