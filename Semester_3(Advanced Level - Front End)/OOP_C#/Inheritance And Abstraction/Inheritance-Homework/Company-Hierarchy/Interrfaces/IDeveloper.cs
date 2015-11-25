namespace Company_Hierarchy.Interrfaces
{
    using System.Collections.Generic;
    using Models;

    public interface IDeveloper
    {
        ICollection<IProject> Projects { get; set; }

        bool CloseProjectById(int id);
    }
}