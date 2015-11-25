namespace Company_Hierarchy
{
    using System.Collections.Generic;
    using Interrfaces;
    using Models;

    public static class CompanyDB
    {
        public static ICollection<Sale> sales;
        public static ICollection<Customer> customers;
        public static ICollection<Product> products;
        public static ICollection<IEmployee> employees;
        public static ICollection<IProject> projects;
 

        static CompanyDB()
        {
            sales = new HashSet<Sale>();
            customers = new HashSet<Customer>();
            products = new HashSet<Product>();
            employees = new HashSet<IEmployee>();
            projects = new HashSet<IProject>();
        }
    }
}