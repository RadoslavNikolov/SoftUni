using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_StoredProcedure
{
    using SuftuniContext;

    class StoredProcedureTest
    {
        static void Main(string[] args)
        {
            GetProjectsByEmployee("Ruth", "Ellerbrock");
        }

        public static void GetProjectsByEmployee(string firstName, string lastName)
        {
            var context = new SuftuniContext();
            var projects = context.usp_GetProjectsByEmployee(firstName, lastName)
                .Select(p => new Project
                {
                    Name = p.Name,
                    Description = p.Description,
                    StartDate = p.StartDate
                }).ToList();

            PrintProjects(projects);
        }
    }
}
