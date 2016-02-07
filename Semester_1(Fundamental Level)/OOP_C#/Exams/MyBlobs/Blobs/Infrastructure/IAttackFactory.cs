namespace Blobs.Infrastructure
{
    using Models.Inftrastructure;

    public interface IAttackFactory
    {
        IAttack CreateAttack(string attackType); 
    }
}