namespace LiskovSubstitutionMovementAfter
{
    using LiskovSubstitutionMovementAfter.Contracts;

    public abstract class MovableObject : IMovable
    {
        public abstract void Move();
    }
}
