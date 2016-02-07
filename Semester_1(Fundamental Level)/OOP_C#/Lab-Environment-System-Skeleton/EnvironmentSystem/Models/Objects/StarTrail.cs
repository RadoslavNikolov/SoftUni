namespace EnvironmentSystem.Models.Objects
{
    using System.Collections.Generic;
    using DataStructures;

    public class StarTrail : EnvironmentObject
    {
        private int turn;

        public StarTrail(int x, int y, int width, int height) : 
            base(x, y, width, height)
        {
            this.ImageProfile = this.GenerateImageProfile();
            this.CollisionGroup = CollisionGroup.StarTrail;
            this.turn++;
        }

        public StarTrail(Rectangle bounds) 
            : base(bounds)
        {
        }

        protected virtual char[,] GenerateImageProfile()
        {
            return new char[,] { { '.' } };
        }

        public override void Update()
        {
            this.turn++;

            if (this.turn % 4 == 0)
            {
                this.Exists = false;
            }
        }

        public override void RespondToCollision(CollisionInfo collisionInfo)
        {
            var hitObjectGroup = collisionInfo.HitObject.CollisionGroup;
            if (hitObjectGroup == CollisionGroup.Explosion)
            {
                this.Exists = false;
            }
        }

        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            return new EnvironmentObject[0];
        }
    }
}