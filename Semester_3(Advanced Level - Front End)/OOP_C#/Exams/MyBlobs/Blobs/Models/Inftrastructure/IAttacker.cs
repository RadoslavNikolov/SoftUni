namespace Blobs.Models.Inftrastructure
{
    public interface IAttacker 
    {
        int AttackDamage { get; set; }

        int InitialDamage { get; set; }
    }
}