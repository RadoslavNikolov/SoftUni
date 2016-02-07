namespace EnvironmentSystem.Core
{
    using System;
    using Interfaces;
    using Models.Objects;

    public class MyEngine : Engine
    {
        protected readonly IController controller;

        public MyEngine(int worldWidth, int worldHeight, IObjectGenerator<EnvironmentObject> objectGenerator, ICollisionHandler collisionHandler, IRenderer renderer, IController controller) : 
            base(worldWidth, worldHeight, objectGenerator, collisionHandler, renderer)
        {
            this.controller = controller;
        }

        protected override void Insert(EnvironmentObject obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException();
            }

            this.objects.Add(obj);
        }
    }
}