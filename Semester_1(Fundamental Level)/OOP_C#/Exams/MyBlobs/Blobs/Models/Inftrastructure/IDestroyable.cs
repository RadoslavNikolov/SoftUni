namespace Blobs.Models.Inftrastructure
{
    public interface IDestroyable
    {
        int Health { get; set; }

        int InitialHeallth { get; }

        void ResponseToAttack(int damage);
    }
}