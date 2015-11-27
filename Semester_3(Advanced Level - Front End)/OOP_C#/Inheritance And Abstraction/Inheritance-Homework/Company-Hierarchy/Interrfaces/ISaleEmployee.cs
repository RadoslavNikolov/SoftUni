namespace Company_Hierarchy.Interrfaces
{
    using System.Collections.Generic;

    public interface ISaleEmployee
    {
        ICollection<ISale> Sales { get; set; }
 
    }
}