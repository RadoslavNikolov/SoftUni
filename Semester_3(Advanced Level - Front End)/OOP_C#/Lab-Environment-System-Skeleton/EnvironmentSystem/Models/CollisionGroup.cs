namespace EnvironmentSystem.Models
{
    using System;

    [Flags]
    public enum CollisionGroup
    {
        Nothing = 0,
        Snowflake = 1,
        Ground = 3,
        Snow = 4,
        Explosion = 5,
        Star = 6,
        FallingStar = 7,
        StarTrail = 8,
        UnstableStar = 9
    }
}
