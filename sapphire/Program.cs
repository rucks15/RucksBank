using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sapphire
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*******************************");
            Console.WriteLine("Welcome to Sapphire Bank");
            
            while(true)
            { 
            Console.WriteLine("Please select an option from below:");
            Console.WriteLine("0.Exit");
            Console.WriteLine("1. Create Account");
            Console.WriteLine("2.Deposit");
            Console.WriteLine("3.Withdraw");
            var choice = Console.ReadLine();
                switch (choice)
                {
                    case "0":
                        Console.WriteLine("Have a great day");
                        return;
                    case "1":
                        Console.Write("Enter the E-Mail Address : ");
                        var emailAddress = Console.ReadLine();
                        var checkingAccount = new Account();
                        checkingAccount.EmailAddress = emailAddress;
                        checkingAccount.AccountType = TypeOfAccounts.Checking;
                        checkingAccount.Deposit(1002.20M);
                        Console.WriteLine($"Account Number:{checkingAccount.AccountNumber },Balance:{checkingAccount.Balance:C}");
                        break;

                    default:
                        break;



                }
            }
        }
    }
}
