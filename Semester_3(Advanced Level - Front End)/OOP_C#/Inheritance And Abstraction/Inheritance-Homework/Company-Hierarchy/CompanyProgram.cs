namespace Company_Hierarchy
{
    using System;
    using System.Linq;
    using Models;

    class CompanyProgram
    {
        static void Main()
        {
            //Test customer, sale and product
            var customer = new Customer("radko", "radkov");
            CompanyDB.customers.Add(customer);

            var product = new Product("test product", 15.5m);
            CompanyDB.products.Add(product);
            Console.WriteLine(product);

            var saleEmployee = new SaleEmployee("sale", "saler", 1500, "sAleS");
            var sale = new Sale(customer.Id, saleEmployee.Id);
            sale.Products.Add(product);
            CompanyDB.sales.Add(sale);
            saleEmployee.Sales.Add(sale);
            CompanyDB.employees.Add(saleEmployee);
            Console.WriteLine(sale);

            var product2 = new Product("product2", 205m);
            sale = CompanyDB.sales.FirstOrDefault(s => s.Id == 1);
            sale.Products.Add(product2);
            Console.WriteLine(sale);

            Console.WriteLine(customer);

            //Test employee and manager
            var manager = new Manager("radko", "radkov", 15000, "pRoductioN");
            Console.WriteLine(manager);
            manager.Employees.Add(saleEmployee);

            CompanyDB.employees.Add(manager);
            CompanyDB.employees.ToList().ForEach(Console.WriteLine);

            Console.WriteLine("Test deletion");
            Console.WriteLine(new string('_', Console.BufferWidth));
            CompanyDB.products.Add(new Product("for deletion", 15000));
            CompanyDB.products.ToList().ForEach(Console.WriteLine);
            manager.DeleteProduct(CompanyDB.products.First(p => p.Name == "for deletion").Id);
            CompanyDB.products.ToList().ForEach(Console.WriteLine);
            Console.WriteLine();
            CompanyDB.sales.ToList().ForEach(Console.WriteLine);
            //Delete sale
            manager.DeleteSale(CompanyDB.sales.First().Id);
            CompanyDB.sales.ToList().ForEach(Console.WriteLine);

            //Test project
            Console.WriteLine("\n\nTest project");
            var project = new Project("test project", DateTime.Now.AddDays(10), "test project later will be closed");
            CompanyDB.projects.Add(project);
            CompanyDB.projects.ToList().ForEach(Console.WriteLine);
            project.CloseProject();
            CompanyDB.projects.ToList().ForEach(Console.WriteLine);

            //Test developer
            Console.WriteLine("\n\nTest developer");
            var dev1 = new Developer("Developer1", "devdssd", 5400, "proDucTion");
            var dev2 = new Developer("Developer2", "cxzddcsad", 6150, "proDucTion");
            var project2 = new Project("test project2", DateTime.Now.AddDays(15), "test project2 later will be closed");
            var project3 = new Project("test project3", DateTime.Now.AddDays(12), "test project3 later will be closed");
            dev1.Projects.Add(project);
            dev2.Projects.Add(project2);
            dev2.Projects.Add(project3);
            project.Developers.Add(dev1);
            project2.Developers.Add(dev2);
            project3.Developers.Add(dev2);
            CompanyDB.projects.Add(project);
            CompanyDB.projects.Add(project2);
            CompanyDB.projects.Add(project3);
            CompanyDB.employees.Add(dev1);
            CompanyDB.employees.Add(dev2);
            CompanyDB.employees.ToList().ForEach(Console.WriteLine);
            //Trying dev1 to close project 2 
            dev1.CloseProjectById(2);
            //Dev2 close project 2
            dev2.CloseProjectById(2);
            //Manager Delete project 3  
            manager.CloseProjectById(3);
            CompanyDB.projects.ToList().ForEach(Console.WriteLine);
        }
    }
}
