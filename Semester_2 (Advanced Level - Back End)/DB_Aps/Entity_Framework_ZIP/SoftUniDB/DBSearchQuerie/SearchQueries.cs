using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSearchQuerie
{
    using System.Diagnostics;
    using SuftuniContext;
    using _02_DAO;

    class SearchQueries
    {
        static void Main(string[] args)
        {
            var context = new SuftuniContext();
            //Problem 3 - 1

            var employees = context.Employees
                .Where(e => e.Projects
                    .Any(p => p.StartDate.Year >= 2001 && p.StartDate.Year <= 2003))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManagerName = e.Employee1.FirstName,
                    Project = e.Projects.ToList()
                }).ToList();


            employees.ForEach(e =>
            {
                Console.WriteLine(e.FirstName + "  " + e.LastName + "  Manager: " + e.ManagerName + "Projects: ");
                e.Project.ForEach(p => Console.WriteLine(" " + p.Name + "  Start Date: " + p.StartDate + "  End Date:  " + p.EndDate + ""));
                Console.WriteLine();
            });




            //Problem 3 - 2
            var addresses = context.Addresses
                .OrderByDescending(a => a.Employees.Count)
                .ThenBy(a => a.Town.Name)
                .Select(a => new
                {
                    a.AddressText,
                    a.Town.Name,
                    Count = a.Employees.Count + " employees"
                })
                .Take(10).ToList();

            addresses.ForEach(a => Console.WriteLine("{0}, {1} - {2}", a.AddressText, a.Name, a.Count));



            //Problem 3 - 3
            var employeeById = context.Employees
                .Where(e => e.EmployeeID == 147)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Projects = e.Projects.Select(p => p.Name)
                }).FirstOrDefault();

            Console.WriteLine("{0}  {1} - {2}   Projects: {3}", employeeById.FirstName, employeeById.LastName, employeeById.JobTitle, string.Join(",  ", employeeById.Projects));



            //Problem 3 - 4
            var departments = context.Departments
                .Where(d => d.Employees.Count > 5)
                .Select(d => new
                {
                    d.Name,
                    Manager =
                        context.Employees.Where(e => e.EmployeeID == d.ManagerID)
                            .Select(m => m.FirstName)
                            .FirstOrDefault(),
                    count = d.Employees.Count,
                    emploiees = d.Employees.Select(e => new
                    {
                        e.FirstName,
                        e.LastName,
                        e.HireDate,
                        e.JobTitle
                    }).ToList()
                }).ToList();

            departments.ForEach(d =>
            {
                Console.WriteLine("--{0} - Manager: {1}, Employees: {2}", d.Name, d.Manager, d.count);
                d.emploiees.ForEach(e => Console.WriteLine("    {0}  {1}  {2}   {3}", e.FirstName, e.LastName, e.JobTitle, e.HireDate));
            });
        }
    }
}
