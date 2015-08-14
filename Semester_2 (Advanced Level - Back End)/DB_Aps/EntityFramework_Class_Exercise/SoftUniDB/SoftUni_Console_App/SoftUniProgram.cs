namespace SoftUni_Console_App
{
    using System;
    using System.Linq;
    using System.Runtime.InteropServices;
    using SoftUniContext;

    class SoftUniProgram
    {
        static void Main(string[] args)
        {
            var context = new SoftUniEntities();

            ////Step 1
            //var employeeNames = context.Employees
            //    .Where(e => e.Salary > 50000)
            //    .Select(e => e.FirstName)
            //    .ToList();

            //employeeNames.ForEach(e => Console.WriteLine(e));

            ////Step 2
            //var employees = context.Employees
            //    .Where(e => e.Department.Name == "Research and Development")
            //    .Select(e => new
            //    {
            //        e.FirstName,
            //        e.LastName,
            //        e.Department.Name,
            //        e.Salary
            //    })
            //    .OrderBy(e => e.Salary)
            //    .ThenByDescending(e => e.FirstName)
            //    .ToList();

            //employees.ForEach(e => 
            //    Console.WriteLine("{0} {1} from {2}  -  ${3:F2}", e.FirstName, e.LastName, e.Name, e.Salary)
            //    );

            ////Step 4
            //var address = new Address()
            //{
            //    AddressText = "Vitoshka 15",
            //    TownID = 4
            //};

            //Employee employee = null;
            //employee = context.Employees
            //    .Where(e => e.LastName == "Nakov")
            //    .FirstOrDefault();

            //Console.WriteLine("{0} {1} : {2}", employee.FirstName, employee.LastName, employee.Address.AddressText);

            //if (employee != null) employee.Address = address;
            //context.SaveChanges();

            //Console.WriteLine("{0} {1} : {2}", employee.FirstName, employee.LastName, employee.Address.AddressText);

            //Step 5
            var project = context.Projects.Find(2);
            var projectName = project.Name;
            Console.WriteLine(projectName);

            var employeesWithProject = project.Employees;

            foreach (var employee in employeesWithProject)
            {
                employee.Projects.Remove(project);
            }

            context.Projects.Remove(project);
            context.SaveChanges();
            Console.WriteLine(projectName ?? "No such project");

        }
    }
}
