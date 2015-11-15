namespace CompanyHierarcgy.Interfaces
{
    using System;
    using Models;

    public interface IProject
    {
        string Name { get; set; }

        string Details { get; set; }

        DateTime StartDate { get; set; }

        ProjectState State { get; set; }

        void CloseProject();
    }
}