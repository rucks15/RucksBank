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
            Console.WriteLine("4.Print All");
             
            var choice = Console.ReadLine();
            
                
                switch (choice)
                {
                    case "0":
                        Console.WriteLine("Have a great day");
                        return;
                    case "1":
                        decimal amt,amt1;
                        Console.Write("Enter the E-Mail Address : ");
                        var emailAddress = Console.ReadLine();
                        var myAccount = Bank.CreateAccount(emailAddress, TypeOfAccounts.Checking);
                        Console.WriteLine($"Account Number:{myAccount.AccountNumber },Balance:{myAccount.Balance:C}");

                        Console.WriteLine("Enter the amount to be deposited:");
                        amt = Decimal.Parse(Console.ReadLine());
                        myAccount.Deposit(amt);

                        Console.WriteLine("Enter the amount to withdraw:");
                        amt1 = Decimal.Parse(Console.ReadLine());
                        myAccount.Withdraw(amt1);
                        myAccount.PrintTransactions();
                        
                        break;
                   

                   case "4":
                        Bank.PrintAllAccounts();
                        break;
                   

                    default:
                        break;



                }
            }
        }
    }
}
