namespace Kurtovo_Konare_Bank.Engine
{
    using System;
    using System.Linq;
    using Interfaces;
    using Models;

    public class BankEngine
    {
        private readonly IRender renderer;
        private readonly IInputHandler inputHandler;

        public BankEngine(IRender renderer, IInputHandler inputHandler)
        {
            this.renderer = renderer;
            this.inputHandler = inputHandler;
            this.IsRunning = true;
        }

        public bool IsRunning { get; private set; }

        public void Run()
        {
            while (this.IsRunning)
            {
                string command = this.inputHandler.ReadLine();

                if (string.IsNullOrWhiteSpace(command))
                {
                    continue;                   
                }

                string[] commandArgs = command.Split();

                string commandResult = this.ExecuteCommand(commandArgs);
                this.renderer.WriteLine(commandResult);
            }
        }

        private string ExecuteCommand(string[] commandArgs)
        {
            switch (commandArgs[0].ToLower())
            {
                case "createcustomer" :
                    return ExecuteCreateCustomer(commandArgs);
                case "createaccount":
                    return this.ExecuteCreateAccount(commandArgs);
            }

            return "test";
        }

        private string ExecuteCreateAccount(string[] commandArgs)
        {
            //[0] - command
            //[1] - customer type
            //[2][3][4] - firstName, address, age
            //[2][3][4] - firstName, address, eik
            string accountName = commandArgs[1].ToLower();

            switch (accountName)
            {                
                case "depositaccount":                
                    var customer = this.GetCustomer(commandArgs[2]);
                    if (customer == null)
                    {
                        return String.Format("Customer with name: {1} does not exists", commandArgs[2]);
                    }
                    if (this.GetAccountByCistomerName(commandArgs[2]) != null)
                    {
                        return String.Format("Deposit account with customer name: {0}  already exists", commandArgs[2]);
                    }
                    var account = new DepositAccount(customer, float.Parse(commandArgs[3]), decimal.Parse(commandArgs[4]));
                    BankDB.accounts.Add(account);
                    break;
                //case "companycustomer" :
                //    if (this.GetCustomer(commandArgs[2]) != null)
                //    {
                //        return String.Format("IndividualCutomer with name: {0}  already exists", commandArgs[2]);
                //    }
                //    var customer1 = new CompanyCustomer(commandArgs[2], commandArgs[3], commandArgs[4]);
                //    BankDB.customers.Add(customer1);
                //    break;
            }

            return String.Format("Customer of type: {0} with name: {1} was successfully created", accountName, commandArgs[2]);
        }

        private Account GetAccountByCistomerName(string customerName)
        {
            return BankDB.accounts.FirstOrDefault(a => a.Customer.Name == customerName);
        }

        private string ExecuteCreateCustomer(string[] commandArgs)
        {
            //[0] - command
            //[1] - customer type
            //[2][3][4] - firstName, address, age
            //[2][3][4] - firstName, address, eik
            string className = commandArgs[1].ToLower();
            
            switch (className)
            {                
                case "individualcustomer":
                    if (this.GetCustomer(commandArgs[2]) != null)
                    {
                        return String.Format("Individual cutomer with name: {0}  already exists", commandArgs[2]);
                    }
                    var customer = new IndividualCustomer(commandArgs[2], commandArgs[3], double.Parse(commandArgs[4]));
                    BankDB.customers.Add(customer);
                    break;
                case "companycustomer" :
                    if (this.GetCustomer(commandArgs[2]) != null)
                    {
                        return String.Format("Individual cutomer with name: {0}  already exists", commandArgs[2]);
                    }
                    var customer1 = new CompanyCustomer(commandArgs[2], commandArgs[3], commandArgs[4]);
                    BankDB.customers.Add(customer1);
                    break;
            }      
            return String.Format("Customer of type: {0} with name: {1} was successfully created", className, commandArgs[2]);
        }


        private Customer GetCustomer(string name)
        {
            return BankDB.customers.FirstOrDefault(c => c.Name == name);
        }
    }
}