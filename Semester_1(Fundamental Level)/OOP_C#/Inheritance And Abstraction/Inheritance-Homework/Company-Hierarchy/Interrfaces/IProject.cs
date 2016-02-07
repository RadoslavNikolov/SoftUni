namespace Company_Hierarchy.Interrfaces
{
    using System;
    using System.Collections.Generic;

    public interface IProject
    {
        int Id { get;}

        string Name { get; set; }

        DateTime StartDate { get; set; }

        string Details { get; set; }

        States State { get; set; }

        ICollection<IPerson> Developers { get; set; }

        void CloseProject();
    }
}