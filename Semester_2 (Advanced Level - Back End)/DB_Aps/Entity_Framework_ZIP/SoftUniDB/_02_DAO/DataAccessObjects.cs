namespace _02_DAO
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using SuftuniContext;

    public static class DataAccessObjects
    {

        public static void Add(Employee employee, SuftuniContext context)
        {

                context.Employees.Add(employee);
                context.SaveChanges();

            
            
        }

        public static Employee FindByKey(object key)
        {
            using (var context = new SuftuniContext())
            {
                var employee = context.Employees.Find(key);

                return employee;
            }
        }



        public static void Modify(Employee employee)
        {
            using (var context = new SuftuniContext())
            {
                var original = context.Employees.Find(employee.EmployeeID);

                context.Entry(original).CurrentValues.SetValues(employee);
                context.SaveChanges();
            }
        }

        


        public static void PrintNamesWithLinqQuery()
        {
            using (var context = new SuftuniContext())
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
            using (var context = new SuftuniContext())
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



        public static string Delete(Employee employee)
        {
            using (var context = new SuftuniContext())
            {
                //var itemToRemove = context.Employees.SingleOrDefault(e => e.EmployeeID == employee.EmployeeID);

                context.Entry(employee).State = EntityState.Deleted;
                context.SaveChanges();
                //
                //                if (itemToRemove != null)
                //                {
                //                    context.Employees.Remove(itemToRemove);
                //                    context.SaveChanges();

                return "Employee deleted";
                //}

                return "Delete failed!";
            }
        }     
    }
}