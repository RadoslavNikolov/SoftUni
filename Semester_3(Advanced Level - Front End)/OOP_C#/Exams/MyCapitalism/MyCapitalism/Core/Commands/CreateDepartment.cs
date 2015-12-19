namespace MyCapitalism.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    using Models.Employees;
    using Models.Interfaces;
    using Models.OrganizationalUnits;

    public class CreateDepartment : CommandAbstract
    {
        private readonly string companyName;
        private readonly string departmentName;
        private readonly string managerFirstName;
        private readonly string managerLastName;
        private readonly string mainDepartmentName;

        public CreateDepartment(IList<string> parameters, ICapitalismData data) 
            : base(parameters, data)
        {
            this.companyName = this.Parameters[0];
            this.departmentName = this.Parameters[1];
            this.managerFirstName = this.Parameters[2];
            this.managerLastName = this.Parameters[3];
            this.mainDepartmentName = null;

            this.mainDepartmentName = this.Parameters.Count >= 5 ? this.Parameters[4] : null;
        }

        public override string Execute()
        {
            Company company = null;
            foreach (Company c
                in this.Data.Companies)
            {
                if (c.Name == this.companyName)
                {
                    company = c;
                    break;
                }
            }

            if (company == null)
            {
                throw new ArgumentException(
                    string.Format("Company {0} does not exist", this.companyName));
            }


            IEmployee manager = null;
            IOrganizationalUnit mainDepartment = null;
            if (this.mainDepartmentName == null)
            {
                foreach (IEmployee employee in company.Employees)
                {
                    if (employee.FirstName == this.managerFirstName && employee.LastName == this.managerLastName)
                    {
                        manager = employee;
                        break;
                    }
                }

                if (manager == null)
                {
                    throw new ArgumentException(
                        string.Format(
                        "There is no employee called {0} {1} in company {2}",
                        this.managerFirstName,
                        this.managerLastName,
                        this.companyName
                        ));
                }
            }
            else
            {

                foreach (IOrganizationalUnit d in company.AllDepartments)
                {
                    if (d.Name == this.mainDepartmentName)
                    {
                        mainDepartment = d;
                        break;
                    }
                }

                if (mainDepartment == null)
                {
                    throw new ArgumentException(
                        string.Format(
                        "There is no department {0} in {1}",
                        this.mainDepartmentName,
                        this.companyName
                        ));
                }

                foreach (IEmployee employee in mainDepartment.Employees)
                {
                    if (employee.FirstName == this.managerFirstName && employee.LastName == this.managerLastName)
                    {
                        manager = employee;
                        break;
                    }
                }

                if (manager == null)
                {
                    throw new ArgumentException(
                        string.Format(
                        "There is no employee called {0} {1} in department {2}",
                        this.managerFirstName,
                        this.managerLastName,
                        this.mainDepartmentName
                        ));
                }

            }

            if (!(manager is Manager))
            {
                string realPosition = manager.GetType().Name;
                throw new TypeLoadException(
                    string.Format(
                    "{0} {1} is not a manager (real position: {2})",
                    this.managerFirstName,
                    this.managerLastName,
                    realPosition));
            }

            foreach (IOrganizationalUnit d in company.SubUnits)
            {
                if (d.Name == this.departmentName)
                {
                    throw new ArgumentException(
                        string.Format(
                            "Department {0} already exists in {1}",
                            this.departmentName,
                            this.companyName
                            )
                        );
                }
            }


            IOrganizationalUnit department = new Department(this.departmentName);
            department.Head = manager;
            //manager.InUnit = department;
            //department.AddEmployee(manager);
            if (this.mainDepartmentName != null)
            {
                mainDepartment.AddSubUnit(department);
                //mainDepartment.RemoveEmployee(manager);
            }
            else
            {
                company.AddSubUnit(department);
                //company.RemoveEmployee(manager);
            }
            company.AllDepartments.Add(department);
            return "";
        }
    }
}
