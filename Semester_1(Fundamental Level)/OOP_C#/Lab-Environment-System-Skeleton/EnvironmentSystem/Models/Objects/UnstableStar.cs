namespace EnvironmentSystem.Models.Objects
{
    using System.Collections.Generic;

    public class UnstableStar : MovingObject
    {
        private int turn;

        public UnstableStar(int x, int y, int width, int height, Point direction) 
            : base(x, y, width, height, direction)
        {
            this.ImageProfile = this.GenerateImageProfile();
            this.CollisionGroup = CollisionGroup.UnstableStar;
            this.turn = 0;
        }

        protected virtual char[,] GenerateImageProfile()
        {
            return new char[,] { { 'B' } };
        }

        public override void RespondToCollision(CollisionInfo collisionInfo)
        {
            var hitObjectGroup = collisionInfo.HitObject.CollisionGroup;
            if (hitObjectGroup == CollisionGroup.Ground || hitObjectGroup == CollisionGroup.Explosion)
            {
                this.Exists = false;
            }
        }

        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            this.turn++;

            if (!this.Exists)
            {
                return new EnvironmentObject[0];
            }

            var objects = new List<EnvironmentObject>();

            objects.Add(new StarTrail(this.Bounds.TopLeft.X - this.Direction.X, this.Bounds.TopLeft.Y - 1, 1, 1));

            if (this.turn % 8 == 0)
            {
                objects.Add(new Explosion(this.Bounds.TopLeft.X-2, this.Bounds.TopLeft.Y-2, 5,5));
                this.Exists = false;
            }

            return objects;
        }
    }
}