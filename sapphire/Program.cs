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
            Console.WriteLine("Enter the email address:");
            var email = Console.ReadLine();
            
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
                        try
                        {
                            //var myAccount = Bank.CreateAccount(email, TypeOfAccounts.Checking);
                            //Console.WriteLine($"Account Number:{myAccount.AccountNumber },Balance:{myAccount.Balance:C}");

                        }

                        catch(Exception ex)
                        {
                            Console.WriteLine($"Error occurred:{ex.Message}");
                        }

                        
                        
                        
                        break;
                    case "2":
                        try
                        {
                            //Bank.PrintAllAccounts(email);
                            Console.Write("Enter the account number for which you want to deposit:");
                            var strAN = Console.ReadLine();
                            var accountnumber = Convert.ToInt32(strAN);

                            Console.WriteLine("Enter the amount to be deposited:");
                            var amt = Convert.ToDecimal(Console.ReadLine());
                            Bank.Deposit(amt, accountnumber);
                        }
                        catch
                        {
                            Console.WriteLine("Deposit failed,please try again");
                        }
                        break;
                    case "3":
                        try
                        {
                            //Bank.PrintAllAccounts(email);
                            Console.Write("Enter the account number for which you want to deposit:");
                            var strAN = Console.ReadLine();
                            var accountnumber = Convert.ToInt32(strAN);

                            Console.WriteLine("Enter the amount to withdraw:");
                            var amt1 = Convert.ToDecimal(Console.ReadLine());
                            Bank.withdraw(accountnumber, amt1);
                        }
                        catch(InvalidOperationException)
                        {
                            Console.WriteLine("Sorry cannot connect to the database.Try again!");
                        }
                        catch(FormatException)
                        {
                            Console.WriteLine("Invalid input, please try again");
                        }
                        catch
                        {
                            Console.WriteLine("Sorry, something went wrong. try again");
                        }
                        break;

                    case "4":
                        //Bank.PrintAllAccounts(email);
                        break;
                   

                    default:
                        break;



                }
            }
        }
    }
}
