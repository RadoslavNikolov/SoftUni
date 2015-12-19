namespace EnvironmentSystem.Models.Objects
{
    using System.Collections.Generic;
    using DataStructures;

    public class Explosion : EnvironmentObject
    {
        private int turn;

        public Explosion(int x, int y, int width, int height) 
            : base(x, y, width, height)
        {
            this.ImageProfile = this.GenerateImageProfile();
            this.CollisionGroup = CollisionGroup.Explosion;
            this.turn++;
        }

        public Explosion(Rectangle bounds) :
            base(bounds)
        {
        }

        protected virtual char[,] GenerateImageProfile()
        {
            return new char[,]
            {
                { '*', '*', '*', '*', '*' },
                { '*', '*', '*', '*', '*' },
                { '*', '*', ' ', '*', '*' },
                { '*', '*', '*', '*', '*' },
                { '*', '*', '*', '*', '*' },
            };
        }

        public override void Update()
        {
            this.turn++;

            if (this.turn % 25 == 0)
            {
                this.Exists = false;
            }
        }

        public override void RespondToCollision(CollisionInfo collisionInfo)
        {
            
        }

        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            return new EnvironmentObject[0];

        }
    }
}