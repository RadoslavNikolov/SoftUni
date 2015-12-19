namespace EnvironmentSystem.Models.Objects
{
    using System;
    using System.Collections.Generic;

    public class FallingStar : MovingObject
    {

        public FallingStar(int x, int y, int width, int height, Point direction)
            : base(x, y, width, height, direction)
        {
            this.ImageProfile = this.GenerateImageProfile();
            this.CollisionGroup = CollisionGroup.FallingStar;
        }

        protected virtual char[,] GenerateImageProfile()
        {
            return new char[,] { { 'o' } };
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
            if (!this.Exists)
            {
                return new EnvironmentObject[0];
            }

            var objects = new List<EnvironmentObject>
            {
                new StarTrail(this.Bounds.TopLeft.X - this.Direction.X, this.Bounds.TopLeft.Y-1, 1, 1)
            };
            return objects;
        }
    }
}