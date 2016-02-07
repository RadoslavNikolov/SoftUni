namespace Blobs.Models.Inftrastructure
{
    public interface IAttack
    {
        IUnit Unit { get; set; }

        int ProduceAttack();
    }
}