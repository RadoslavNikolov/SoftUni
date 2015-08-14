namespace _02_DAO
{
    using System;
    using System.Linq;
    using SuftuniContext;

    class ProgramTest
    {
        static void Main(string[] args)
        {
            var context = new SuftuniContext();

            var test1 = context.Employees
                .FirstOrDefault(e => e.FirstName == "Radko1");

            Console.WriteLine(test1 == null ? "No such employee" : test1.FirstName);

            var newEmployee = context.Employees.FirstOrDefault();
            if (newEmployee != null)
            {
                newEmployee.FirstName = "Radko1";
                newEmployee.LastName = "Radkov";
                newEmployee.HireDate = DateTime.Now;
            }

            DataAccessObjects.Add(newEmployee,context);

            var test = context.
                Employees.FirstOrDefault(e => e.FirstName == "Radko1");

            Console.WriteLine(test == null ? "No such employee" : test.FirstName);


            Console.WriteLine("2. Find employee by key");
            if (newEmployee != null)
            {
                var employee = DataAccessObjects.FindByKey(newEmployee.EmployeeID);
                Console.WriteLine("   -- {0} {1}", employee.FirstName, employee.LastName);

                Console.WriteLine("3. Edit employee first name");
                employee.FirstName = "Todor";
                Console.WriteLine("   -- New name: {0} {1}", employee.FirstName, employee.LastName);

                Console.WriteLine("4. Delete employee");
                Console.WriteLine("   -- {0}", DataAccessObjects.Delete(employee));
            }
        }
    }
}
