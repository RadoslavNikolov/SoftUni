namespace Company_Hierarchy.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using Helpers;
    using Interrfaces;

    public class Manager : Employee, IManager
    {
        private ICollection<IEmployee> employees;
 
        public Manager(string firstName, string lastName, decimal salary, string department) 
            : base(firstName, lastName, salary, department)
        {
            this.employees = new HashSet<IEmployee>();
        }

        public virtual ICollection<IEmployee> Employees
        {
            get { return this.employees; }
            set
            {
                this.employees = value;
            }
        }

        public bool DeleteSale(int saledId)
        {
            bool isDeleted = false;
            Sale saleToDelete = CompanyDB.sales.FirstOrDefault(s => s.Id == saledId);

            if (saleToDelete != null)
            {
                if (RightsValidator.ValidateSaleDeletionUserRights())
                {
                    CompanyDB.sales.Remove(saleToDelete);
                    isDeleted = true;
                }
                else
                {
                    Console.WriteLine("You do not have rights to delete sale with id: " + saledId);
                    return isDeleted;
                }       
            }

            if (isDeleted)
            {
                Console.WriteLine("Successfully deleted sale with id: " + saledId);
            }
            else
            {
                Console.WriteLine("There is no sale with id: " + saledId);
            }

            return isDeleted;
        }

        public bool DeleteProduct(int productId)
        {
            bool isDeleted = false;
            Product productToDelete = CompanyDB.products.FirstOrDefault(p => p.Id == productId);

            if (productToDelete != null)
            {
                if (RightsValidator.ValidateProductDeletionUserRights())
                {
                    CompanyDB.products.Remove(productToDelete);
                    isDeleted = true;
                }
                else
                {
                    Console.WriteLine("You do not have rights to delete product with id: " + productId);
                    return isDeleted;
                }
            }

            if (isDeleted)
            {
                Console.WriteLine("Successfully deleted product with id: " + productId);
            }
            else
            {
                Console.WriteLine("There is no product with id: " + productId);
            }

            return isDeleted;
        }

        public bool CloseProjectById(int projectId)
        {
            if (!RightsValidator.ValidateProjectClosingUserRights(projectId, this.Id))
            {
                Console.WriteLine("You do not have rights to close project with id: " + projectId);
                return false;

            }

            CompanyDB.projects.FirstOrDefault(p => p.Id == projectId).State = States.Close;
            Console.WriteLine("Employee: " + this.FirstName + " successfully closed oroject with id: " + projectId);

            return true;
        }

        public override string ToString()
        {
            var output = new StringBuilder(base.ToString());
            output.AppendLine("Under my management:  " + this.Employees.Count + "  employees.  List them all:");
            this.Employees.ToList().ForEach(e => output.AppendLine(e.ToString()));
            Console.WriteLine(new string('-', Console.BufferWidth));
            return output.ToString();
        }
    }
}