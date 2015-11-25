namespace Company_Hierarchy.Interrfaces
{
    public interface IProduct
    {
        int Id { get;}

        string Name { get; set; }

        decimal Price { get; set; }
    }
}