namespace EnvironmentSystem.Models.Objects
{
    using System;
    using System.Collections.Generic;
    using DataStructures;

    public class Star : EnvironmentObject
    {
        private int turn = 0;
        private static readonly Random Rand;
        private static readonly char[] Chars;

        static Star()
        {
            Rand = new Random();
            Chars = new char[]
            {
                'o','@','0'
            };
        }

        public Star(int x, int y, int width, int height) 
            : base(x, y, width, height)
        {
            this.ImageProfile = this.GenerateImageProfile();
            this.CollisionGroup = CollisionGroup.Star;
            this.turn ++;
            
        }

        public Star(Rectangle bounds) 
            : base(bounds)
        {
        }

        protected virtual char[,] GenerateImageProfile()
        {
            var index = Star.Rand.Next(0, 3);
            return new char[,] { { Star.Chars[index] } };
        }

        public override void Update()
        {
            this.turn++;
            if (this.turn % 10 == 0)
            {
                this.ImageProfile = this.GenerateImageProfile();
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