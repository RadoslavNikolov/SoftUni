namespace Kurtovo_Konare_Bank.Engine
{
    using System;
    using System.Globalization;
    using System.Linq;
    using Factury;
    using Interfaces;
    using Models;

    public class BankEngine
    {
        private readonly IRender renderer;
        private readonly IInputHandler inputHandler;
        private readonly IAccounting accounting;

        public BankEngine(IRender renderer, IInputHandler inputHandler, IAccounting accounting)
        {
            this.renderer = renderer;
            this.inputHandler = inputHandler;
            this.accounting = accounting;
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
                case "deposit":
                    return ExecuteDepositAmount(commandArgs);
                case "withdraw":
                    return WithdrawAmount(commandArgs);
                case "interest":
                    return CalculateInterest(commandArgs);
                case "printaccount":
                    return PrintAccount(commandArgs);
            }

            return "Goodbye!";
        }

        private string PrintAccount(string[] commandArgs)
        {
            //[0] - command
            //[1] - customer name

            return this.accounting.PrintAccount(commandArgs[1]);
        }

        private string CalculateInterest(string[] commandArgs)
        {
            //[0] - command
            //[1] - customer name
            //[2] - months

            return this.accounting.CalculateInterest(commandArgs[1], int.Parse(commandArgs[2]));
        }

        private string WithdrawAmount(string[] commandArgs)
        {
            //[0] - command
            //[1] - customer name
            //[2] - amount

            return this.accounting.WithDrawAmount(commandArgs[1], decimal.Parse(commandArgs[2]));
        }

        private string ExecuteDepositAmount(string[] commandArgs)
        {
            //[0] - command
            //[1] - customer name
            //[2] - amount

            return this.accounting.DepositAmount(commandArgs[1], decimal.Parse(commandArgs[2]));
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
                    var customer = CustomerFactory.GetCustomerByName(commandArgs[2]);
                    if (customer == null)
                    {
                        return String.Format("Customer with name: {1} does not exists", commandArgs[2]);
                    }
                    if (AccountFactory.GetAccountByCustomerName(commandArgs[2]) != null)
                    {
                        return String.Format("Deposit account with customer name: {0}  already exists", commandArgs[2]);
                    }
                    var account = new DepositAccount(customer, float.Parse(commandArgs[3], CultureInfo.InvariantCulture), decimal.Parse(commandArgs[4], CultureInfo.InvariantCulture));
                    BankDB.accounts.Add(account);
                    break;
                case "loanaccount":
                    var customer1 = CustomerFactory.GetCustomerByName(commandArgs[2]);
                    if (customer1 == null)
                    {
                        return String.Format("Customer with name: {1} does not exists", commandArgs[2]);
                    }
                    if (AccountFactory.GetAccountByCustomerName(commandArgs[2]) != null)
                    {
                        return String.Format("Loan account with customer name: {0}  already exists", commandArgs[2]);
                    }
                    var account1 = new LoanAccount(customer1, float.Parse(commandArgs[3], CultureInfo.InvariantCulture), decimal.Parse(commandArgs[4], CultureInfo.InvariantCulture));
                    BankDB.accounts.Add(account1);
                    break;
                case "mortageaccount":
                    var customer2 = CustomerFactory.GetCustomerByName(commandArgs[2]);
                    if (customer2 == null)
                    {
                        return String.Format("Customer with name: {1} does not exists", commandArgs[2]);
                    }
                    if (AccountFactory.GetAccountByCustomerName(commandArgs[2]) != null)
                    {
                        return String.Format("Mortage account with customer name: {0}  already exists", commandArgs[2]);
                    }
                    var account2 = new LoanAccount(customer2, float.Parse(commandArgs[3], CultureInfo.InvariantCulture), decimal.Parse(commandArgs[4], CultureInfo.InvariantCulture));
                    BankDB.accounts.Add(account2);
                    break;
            }

            return String.Format("Account of type: {0} with customer name: {1} was successfully created", accountName, commandArgs[2]);
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
                    if (CustomerFactory.GetCustomerByName(commandArgs[2]) != null)
                    {
                        return String.Format("Individual cutomer with name: {0}  already exists", commandArgs[2]);
                    }
                    var customer = new IndividualCustomer(commandArgs[2], commandArgs[3], double.Parse(commandArgs[4]));
                    BankDB.customers.Add(customer);
                    break;
                case "companycustomer" :
                    if (CustomerFactory.GetCustomerByName(commandArgs[2]) != null)
                    {
                        return String.Format("Company cutomer with name: {0}  already exists", commandArgs[2]);
                    }
                    var customer1 = new CompanyCustomer(commandArgs[2], commandArgs[3], commandArgs[4]);
                    BankDB.customers.Add(customer1);
                    break;
            }      
            return String.Format("Customer of type: {0} with name: {1} was successfully created", className, commandArgs[2]);
        }     
    }
}