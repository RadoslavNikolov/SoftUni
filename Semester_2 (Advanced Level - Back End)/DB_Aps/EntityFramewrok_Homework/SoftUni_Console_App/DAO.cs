namespace SoftUni_Console_App
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public static class Dao
    {
        public static void Add(Employee employee, SoftUniEntities context)
        {
            context.Employees.Add(employee);
            context.SaveChanges();
        }

        public static Employee FindByKey(object key)
        {
            using (var context = new SoftUniEntities())
            {
                var employee = context.Employees.FirstOrDefault(e => e.EmployeeID == (int)key);

                return employee;
            }

        }

        public static void Modify(Employee employee)
        {
            using (var context = new SoftUniEntities())
            {                
                context.Employees.AddOrUpdate(e => e.FirstName); 
            }

        }


        public static void PrintNamesWithLinqQuery()
        {
            using (var context = new SoftUniEntities())
            {
                
                var employees = context.Employees
                    .Where(e => e.Projects
                        .Any(p => p.StartDate.Year == 2002))
                    .Select(e => e.FirstName)
                    .ToList();
                employees.ForEach(e => Console.WriteLine(e));               
            }

        }

        public static void PrintNamesWithNativeQuery()
        {
            using (var context = new SoftUniEntities())
            {
                string query = "select e.FirstName from Employees e " +
                            "join EmployeesProjects  ep" +
                                "ep.EmployeeID = e.EmployeeID" +
                            "join Projects p" +
                                "on ep.ProjectID = p.ProjectID" +
                            "where DATEPART(yyyy, p.StartDate) = 2002";

                var queryResult = context.Database.SqlQuery<Employee>(query);
                //foreach (var employee in queryResult)
                //{
                //    Console.WriteLine(employee.FirstName);
                //}
            }  
       
        }
          
    }
}